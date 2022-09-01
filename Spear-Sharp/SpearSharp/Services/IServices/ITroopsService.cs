using System;
using SpearSharp.Models;
using SpearSharp.Models.DTOs;

namespace SpearSharp.Services
{
	public interface ITroopsService
	{
		List<TroopDTO> GetTroopsListDTOByKingdomId(int id);
	}
}

