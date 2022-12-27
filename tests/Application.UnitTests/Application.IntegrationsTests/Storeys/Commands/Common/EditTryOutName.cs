using Application.Common.Interfaces;
using Application.Common.Models;
using Application.StoreysCQR.Commands;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEnergyPerformanceTests.Application.IntegrationsTests.Storeys.Commands.Common
{
    internal class EditTryOutName
    {
        IApplicationDbContext context;
        IMapper mapper;
        int id;
        internal EditTryOutName()
        {
            GetContexMapper getContexMapper = new();
            context = getContexMapper.Context;
            mapper = getContexMapper.Mapper;
            //The id is gotten from the first record.
            id = context.Storeys.OrderBy(x => x.Id).FirstOrDefault().Id;
        }

        public async Task TryName(string str)
        {
            StoreysDto storeyDto = new();
            EditStorey editStorey = new(context, mapper);
            storeyDto.Name = str;

            storeyDto.Id = id;

            try
            {
                await editStorey.ModifyStorey(storeyDto);
            }
            catch
            {
                throw;
            }
        }
    }
}
