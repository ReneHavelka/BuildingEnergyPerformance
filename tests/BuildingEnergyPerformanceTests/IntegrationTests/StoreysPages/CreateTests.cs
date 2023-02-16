using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using System.Diagnostics;

namespace BuildingEnergyPerformanceTests.Application.IntegrationTests.StoreyPages
{
	[TestClass]
	public class CreateTests
	{
		internal async Task<string> TryOutNameAsync(string? name)
		{
			var mockSet = new Mock<DbSet<Storey>>();
			var mockContext = new Mock<ApplicationDbContext>();
			mockContext.Setup(m => m.Storeys).Returns(mockSet.Object);

			var mappingProfile = new MappingProfile();
			var config = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
			var mapper = new Mapper(config);

			var service = new WebUI.Pages.StoreyPages.CreateModel(mockContext.Object, mapper);
			service.StoreyDto = new() { Name = name };

			string exMessage = String.Empty;
			try
			{
				await service.OnPostAsync();

				mockSet.Verify(m => m.AddAsync(It.IsAny<Storey>(), default), Times.Once());
				mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());
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

		//Regular adding
		[TestMethod]
		public async Task RegularAddingAsync()
		{
			//Name is correct.
			var exMessage = await TryOutNameAsync("Abcd");
			Assert.AreEqual(exMessage, String.Empty);
		}
	}
}
