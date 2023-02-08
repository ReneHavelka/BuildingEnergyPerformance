using Application.Common.Interfaces;
using AutoMapper;
using BuildingEnergyPerformanceTests.CommonServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Diagnostics;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.StoreysPages
{
	[TestClass]
	public class CreateTests
	{
		IApplicationDbContext context;
		IMapper mapper;
		public CreateTests()
		{
			var getContextMapper = new GetContexMapper();
			context = getContextMapper.Context;
			mapper = getContextMapper.Mapper;
		}

		internal async Task<string> TryOutNameAsync(string? name)
		{
			var createModel = new WebUI.Pages.StoreysPages.CreateModel(context, mapper);
			createModel.StoreyDto = new() { Name = name };
			string exMessage = "OK";

			try
			{
				await createModel.OnPostAsync();
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
		public async Task NameShouldNotBeNullAsync()
		{
			var exMessage = await TryOutNameAsync(null);
			Assert.IsTrue(exMessage.Contains("Meno je povinné."));
			exMessage = await TryOutNameAsync(" ");
			Assert.IsTrue(exMessage.Contains("Meno je povinné."));
		}

		//The name must consist of 4 characters at least.
		[TestMethod]
		public async Task MinimalNameLengthAsync()
		{
			var exMessage = await TryOutNameAsync("ABC");
			Assert.IsTrue(exMessage.Contains("Meno musí pozostávať minimálne zo 4 znakov."));
		}

		//The name must beginn with a letter.
		[TestMethod]
		public async Task NameFirstCharacterAsync()
		{
			var exMessage = await TryOutNameAsync("1bcd");
			Assert.IsTrue(exMessage.Contains("Meno musí začínať veľkým písmenom."));
		}

		//The name must beginn with a capital letter.
		[TestMethod]
		public async Task NameFirstUpperCharacterAsync()
		{
			var exMessage = await TryOutNameAsync("abcd");
			Assert.IsTrue(exMessage.Contains("Meno musí začínať veľkým písmenom."));
		}

		//The name must consist of the maximum of 20 characters.
		[TestMethod]
		public async Task MaximalNameLengthAsync()
		{
			var exMessage = await TryOutNameAsync("A23456789012345678901");
			Assert.IsTrue(exMessage.Contains("Meno musí mať maximálne 20 znakov."));
		}

		//The name must be distinct from the others. Take out the last name and try to add.
		[TestMethod]
		public async Task DistinctNameAsync()
		{
			//Take last record.
			var lastName = context.Storeys.OrderBy(x => x.Id).Select(x => x.Name).LastOrDefault();
			var exMessage = await TryOutNameAsync(lastName);
			Assert.IsTrue(exMessage.Contains("Toto meno je už použité. Zadajte iné."));
		}
		//Regular adding
		[TestMethod]
		public async Task RegularAddingAsync()
		{
			//Add item.
			var exMessage = await TryOutNameAsync("Abcde");

			Assert.IsTrue(exMessage.Contains("OK"));

			//Delete last record.
			var lastRecord = context.Storeys.OrderBy(x => x.Id).LastOrDefault();
			var lastRecordName = lastRecord.Name;
			Assert.AreEqual("Abcde", lastRecordName);

			context.Storeys.Remove(lastRecord);
			await context.SaveChangesAsync();
		}
	}
}
