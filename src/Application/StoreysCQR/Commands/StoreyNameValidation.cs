using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StoreysCQR.Commands
{
	public class StoreyNameValidation
	{
		public void StoreyNameValidate(StoreysDto storeyDto, IApplicationDbContext context)
		{
			//Exceptions - the name of the storey must
			//- not be null or empty.
			if (storeyDto.Name == null || storeyDto.Name == String.Empty) throw new ArgumentException($"Storey name must not be null or empty.");
			//- consist of 4 characters at least.
			if (storeyDto.Name.Length < 4) throw new ArgumentException("Storey name must consist of 4 characters at least.");
			//- beginn with a capital letter.
			var firstChar = storeyDto.Name[0];
			if (!char.IsLetter(firstChar) || !char.IsUpper(firstChar)) throw new ArgumentException("Storey name must beginn with a capital letter.");
			//- cosist of the maximum of 20 characters.
			if (storeyDto.Name.Length > 20) throw new ArgumentException("Storey name must consist of the maximum of 20 characters.");
			//- be distinct from the others.
			var sameNames = context.Storeys.Select(x => x.Name).Where(x => x.Equals(storeyDto.Name));
			if (sameNames.Any()) throw new ArgumentException($"The name must be different, {storeyDto.Name} already exists.");
		}
	}
}
