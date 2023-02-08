using Application.Common.Interfaces;
using AutoMapper;
using BuildingEnergyPerformanceTests.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.StoreysPages
{
	[TestClass]
	public class EditTests
	{
		IApplicationDbContext context;
		IMapper mapper;
		public EditTests()
		{
			var getContextMapper = new GetContexMapper();
			context = getContextMapper.Context;
			mapper = getContextMapper.Mapper;
		}

		async Task CreateRecord()
		{
			var createRecord = new CreateTests();
			await createRecord.TryOutNameAsync("Abcde");
		}
		async Task<string> TryOutNameAsync(string? name)
		{

			string exMessage = "OK";

			try
			{
				//await editModel.OnPostAsync();
			}
			catch (Exception ex)
			{
				exMessage = ex.Message;
				return exMessage;
			}

			return exMessage;
		}

	}
}
