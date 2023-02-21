using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Diagnostics;
using WebUI.Pages.StoreyPages;

namespace BuildingEnergyPerformanceTests.IntegrationTests.StoreyPages
{
	[TestClass]
	public class CreateEditTests
	{
		internal async Task<(Mock<DbSet<Storey>>, Mock<ApplicationDbContext>, Mapper)> ContextMapper()
		{
			var data = new List<Storey>
			{
				new Storey { Id = 1, Name = "Abcdef" },
				new Storey { Id = 2, Name = "Abcdefg" },
				new Storey {Id = 3, Name = "Abcdefgh" }
				}.AsQueryable();

			var mockSet = new Mock<DbSet<Storey>>();
			mockSet.As<IQueryable<Storey>>().Setup(m => m.Provider).Returns(data.Provider);
			mockSet.As<IQueryable<Storey>>().Setup(m => m.Expression).Returns(data.Expression);
			mockSet.As<IQueryable<Storey>>().Setup(m => m.ElementType).Returns(data.ElementType);
			mockSet.As<IQueryable<Storey>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

			var mockContext = new Mock<ApplicationDbContext>();
			mockContext.Setup(m => m.Storeys).Returns(mockSet.Object);
			var context = mockContext.Object;

			var mappingProfile = new MappingProfile();
			var config = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
			var mapper = new Mapper(config);

			return (mockSet, mockContext, mapper);
		}

		internal async Task<string> CreateTryOutNameAsync(string? name)
		{
			var (mockSet, mockContext, mapper) = await ContextMapper();

			var service = new CreateModel(mockContext.Object, mapper);
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

		internal async Task<string> EditTryOutNameAsync(string? name)
		{
			var (mockSet, mockContext, mapper) = await ContextMapper();

			var service = new EditModel(mockContext.Object, mapper);
			service.StoreyDto = new() { Id = 3, Name = name };
			string exMessage = String.Empty;

			try
			{
				await service.OnPostAsync();

				mockSet.Verify(m => m.Update(It.IsAny<Storey>()), Times.Once());
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
			string expectedMessage = "Meno je povinné.";
			var exMessage = await CreateTryOutNameAsync(null);
			Assert.IsTrue(exMessage.Contains(expectedMessage));
			exMessage = await CreateTryOutNameAsync(" ");
			Assert.IsTrue(exMessage.Contains(expectedMessage));

			exMessage = await EditTryOutNameAsync(null);
			Assert.IsTrue(exMessage.Contains(expectedMessage));
			exMessage = await EditTryOutNameAsync(" ");
			Assert.IsTrue(exMessage.Contains(expectedMessage));
		}

		//The name must consist of 4 characters at least.
		[TestMethod]
		public async Task MinimalNameLengthAsync()
		{
			string expectedMessage = "Meno musí pozostávať minimálne zo 4 znakov.";
			var exMessage = await CreateTryOutNameAsync("ABC");
			Assert.IsTrue(exMessage.Contains(expectedMessage));

			exMessage = await EditTryOutNameAsync("ABC");
			Assert.IsTrue(exMessage.Contains(expectedMessage));
		}

		//The name must beginn with a letter.
		[TestMethod]
		public async Task NameFirstCharacterAsync()
		{
			string expectedMessage = "Meno musí začínať veľkým písmenom.";
			var exMessage = await CreateTryOutNameAsync("1bcd");
			Assert.IsTrue(exMessage.Contains(expectedMessage));

			exMessage = await EditTryOutNameAsync("1bcd");
			Assert.IsTrue(exMessage.Contains(expectedMessage));
		}

		//The name must beginn with a capital letter.
		[TestMethod]
		public async Task NameFirstUpperCharacterAsync()
		{
			string expectedMessage = "Meno musí začínať veľkým písmenom.";
			var exMessage = await CreateTryOutNameAsync("abcd");
			Assert.IsTrue(exMessage.Contains(expectedMessage));

			exMessage = await EditTryOutNameAsync("abcd");
			Assert.IsTrue(exMessage.Contains(expectedMessage));
		}

		//The name must consist of the maximum of 20 characters.
		[TestMethod]
		public async Task MaximalNameLengthAsync()
		{
			string expectedMessage = "Meno musí mať maximálne 20 znakov.";
			var exMessage = await CreateTryOutNameAsync("A23456789012345678901");
			Assert.IsTrue(exMessage.Contains(expectedMessage));

			exMessage = await EditTryOutNameAsync("A23456789012345678901");
			Assert.IsTrue(exMessage.Contains(expectedMessage));
		}

		//Avoid name duplicity.
		[TestMethod]
		public async Task AvoidNameDuplicityAsync()
		{
			string expectedMessage = "Toto meno je už použité. Zadaj iné.";
			var exMessage = await CreateTryOutNameAsync("Abcdefg");
			Assert.IsTrue(exMessage.Contains(expectedMessage));

			exMessage = await EditTryOutNameAsync("Abcdefg");
			Assert.IsTrue(exMessage.Contains(expectedMessage));
		}

		//Regular adding
		[TestMethod]
		public async Task RegularAddingAsync()
		{
			//Name is correct.
			var exMessage = await CreateTryOutNameAsync("Abcd");
			Assert.AreEqual(exMessage, String.Empty);

			exMessage = await EditTryOutNameAsync("Abcd");
			Assert.AreEqual(String.Empty, exMessage);
		}
	}
}
