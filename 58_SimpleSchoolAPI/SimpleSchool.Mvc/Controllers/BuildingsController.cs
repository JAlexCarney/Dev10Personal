using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleSchool.Core.Entities;
using SimpleSchool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSchool.Mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IRoomRepository _roomRepository;

        public BuildingsController(IBuildingRepository buildingRepository, IRoomRepository roomRepository) 
        {
            _buildingRepository = buildingRepository;
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public IActionResult GetBuildings()
        {
            var result = _buildingRepository.GetAll();

            if (result.Success)
            {
                return Ok(
                    result.Data.Select(
                        b => new { b.BuildingID, b.BuildingName })
                    );
            }
            else
            {
                throw new Exception(result.Messages[0]);
            }
        }

        [HttpGet]
        [Route("/api/[controller]/{id}", Name = "GetBuilding")]
        public IActionResult GetBuilding(int id)
        {
            var result = _buildingRepository.Get(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Messages);
            }
        }

        [HttpGet]
        [Route("/api/[controller]/{id}/rooms")]
        public IActionResult GetRoomsByBuilding(int id)
        {
            if (!_buildingRepository.Get(id).Success)
            {
                return NotFound($"Building {id} not found");
            }

            var result = _roomRepository.GetByBuilding(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Messages);
            }
        }

        [HttpPost]
        public IActionResult AddBuilding(string buildingName)
        {
            Building b = new Building();
            b.BuildingName = buildingName;

            var result = _buildingRepository.Add(b);

            if (result.Success)
            {
                return CreatedAtRoute(nameof(GetBuilding), new { id = b.BuildingID }, b);
            }
            else
            {
                return BadRequest(result.Messages);
            }
        }

        [HttpPut]
        public IActionResult EditBuilding(Building building)
        {
            if (!_buildingRepository.Get(building.BuildingID).Success)
            {
                return NotFound($"Building {building.BuildingID} not found");
            }

            var result = _buildingRepository.Edit(building);

            if (result.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Messages);
            }
        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult DeleteBuilding(int id)
        {
            if (!_buildingRepository.Get(id).Success)
            {
                return NotFound($"Building {id} not found");
            }

            var result = _buildingRepository.Delete(id);

            if (result.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Messages);
            }
        }
    }
}
