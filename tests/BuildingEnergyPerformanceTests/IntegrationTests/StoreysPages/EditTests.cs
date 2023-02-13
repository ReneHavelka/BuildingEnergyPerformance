using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;
using BuildingEnergyPerformanceTests.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BuildingEnergyPerformanceTests.Application.IntegrationTests.StoreysPages
{
	[TestClass]
	public class EditTests
	{
		IMapper mapper;
		public EditTests()
		{
			var getContextMapper = new GetContexMapper();
			mapper = getContextMapper.Mapper;
		}

		//Create new record
		async Task NewRecordAsync()
		{
			var context = new GetContexMapper().Context;
			var lastRecord = await context.Storeys.AsNoTracking().OrderBy(x => x.Id).LastOrDefaultAsync();
			if (lastRecord.Name == "Abcd") return;

			Storeys storey = new();
			storey.Name = "Abcd";
			await context.Storeys.AddAsync(storey);
			await context.SaveChangesAsync();
		}

		//Send name to validate
		async Task<string> TryOutNameAsync(string? name)
		{
			await NewRecordAsync();
			var context = new GetContexMapper().Context;
			var lastRecord = await context.Storeys.AsNoTracking().OrderBy(x => x.Id).LastOrDefaultAsync();
			int id = lastRecord.Id;

			var editModel = new WebUI.Pages.StoreysPages.EditModel(context, mapper);
			editModel.StoreyDto = new() { Id = id, Name = name };

			string exMessage = string.Empty;

			try
			{
				await editModel.OnPostAsync();
			}
			catch (Exception ex)
			{
				exMessage = ex.Message;
				return exMessage;
			}

			return exMessage;
		}


		//The name of the storey should not be null.
		[TestMethod]
		public async Task Test1NameShouldNotBeNullAsync()
		{
			var exMessage = await TryOutNameAsync(null);
			Assert.IsTrue(exMessage.Contains("Meno je povinné."));
			exMessage = await TryOutNameAsync(" ");
			Assert.IsTrue(exMessage.Contains("Meno je povinné."));
		}

		//The name must consist of 4 characters at least.
		[TestMethod]
		public async Task Test2MinimalNameLengthAsync()
		{
			var exMessage = await TryOutNameAsync("ABC");
			Assert.IsTrue(exMessage.Contains("Meno musí pozostávať minimálne zo 4 znakov."));
		}

		//The name must beginn with a letter.
		[TestMethod]
		public async Task Test3NameFirstCharacterAsync()
		{
			var exMessage = await TryOutNameAsync("1bcd");
			Assert.IsTrue(exMessage.Contains("Meno musí začínať veľkým písmenom."));
		}

		//The name must beginn with a capital letter.
		[TestMethod]
		public async Task Test4NameFirstUpperCharacterAsync()
		{
			var exMessage = await TryOutNameAsync("abcd");
			Assert.IsTrue(exMessage.Contains("Meno musí začínať veľkým písmenom."));
		}

		//The name must consist of the maximum of 20 characters.
		[TestMethod]
		public async Task Test5MaximalNameLengthAsync()
		{
			var exMessage = await TryOutNameAsync("A23456789012345678901");
			Assert.IsTrue(exMessage.Contains("Meno musí mať maximálne 20 znakov."));
		}

		//The name must be distinct from the others. Take out the last name and try to add.
		[TestMethod]
		public async Task Test6DistinctNameAsync()
		{
			//Take first record.
			var context = new GetContexMapper().Context;
			var firstName = await context.Storeys.OrderBy(x => x.Id).Select(x => x.Name).FirstOrDefaultAsync();
			var exMessage = await TryOutNameAsync(firstName);
			Assert.IsTrue(exMessage.Contains("Toto meno je už použité. Zadajte iné."));
		}

		//Regular editing
		[TestMethod]
		public async Task Test7RegularEditingAsync()
		{
			//Acceptable name - "Abcde"
			var context = new GetContexMapper().Context;
			var exMessage = await TryOutNameAsync("Abcde");
			Debug.WriteLine(exMessage);
			var lastRecord = await context.Storeys.AsNoTracking().OrderBy(x => x.Id).LastOrDefaultAsync();

			Assert.AreEqual("Abcde", lastRecord.Name);

			//To delete last record
			context.Storeys.Remove(lastRecord);
			await context.SaveChangesAsync();
		}
	}
}
