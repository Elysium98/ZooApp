using AutoMapper;
using Bissoft.Interview.API.DTOs;
using Bissoft.Interview.Data.Entities;
using Bissoft.Interview.Services.Interfaces;
using Bissoft.Interview.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bissoft.Interview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZooController : ControllerBase
    {
        private readonly IZooKeeperService _zooKeeperService;
        private readonly IAnimalService _animalService;
        private readonly IMapper _mapper;
        public ZooController(IZooKeeperService zooKeeperService, IAnimalService animalService, IMapper mapper)
        {
            _zooKeeperService = zooKeeperService;
            _animalService = animalService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ZooKeeperDTO>>> GetZooKeepers()
        {

            var all = _zooKeeperService.GetAll();
            var modelToDTO = _mapper.Map<List<ZooKeeperDTO>>(all);

            return Ok(modelToDTO);
        }

        [HttpGet("animals")]
        public async Task<ActionResult<List<AnimalDTO>>> GetAnimals()

        {
            var all = _animalService.GetAll();
            var modelToDTO = _mapper.Map<List<AnimalDTO>>(all);

            return Ok(modelToDTO);
        }

        [HttpGet("animals/{id}")]
        public async Task<ActionResult<IList<AnimalDTO>>> GetAnimalsByZooKeeper(int id)
        {
            var all = _animalService.GetAllByZooKeeper(id);
            var modelToDTO = _mapper.Map<List<AnimalDTO>>(all);

            return Ok(modelToDTO);
        }


        /// <summary>
        /// Delete the animal
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("animals/{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            try
            {
                if (!_animalService.Delete(id))
                {
                    return NotFound();
                }
                return Ok("Animal deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Add a animal
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        [HttpPost("animals")]
        public IActionResult CreateAnimal(Animal animal)
        {
            try
            {
                if (animal == null)
                {
                    return BadRequest("Animal cannot be null");
                }

                _animalService.Add(animal);

                return Ok(animal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets a zookeeper with a certain id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetZooKeeperById(int id)
        {
            try
            {
                ZooKeeper foundZookeeper = _zooKeeperService.FindById(id);
                var modelToDTO = _mapper.Map<ZooKeeperDTO>(foundZookeeper);

                if (foundZookeeper == null)
                {
                    return NotFound();
                }

                return Ok(modelToDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Add a zookeeper
        /// </summary>
        /// <param name="zooKeeper"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult CreateZooKeeper(ZooKeeper zooKeeper)
        {
            try
            {
                if (zooKeeper == null)
                {
                    return BadRequest("Zookeeper cannot be null");
                }

                _zooKeeperService.Add(zooKeeper);

                return Ok(zooKeeper);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Delete the zookeeper
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteZookeeper(int id)
        {
            try
            {
                if (!_zooKeeperService.Delete(id))
                {
                    return NotFound();
                }
                return Ok("Zookeeper deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Update the zookeeper
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateZookeeper(int id, ZooKeeper zooKeeper)
        {
            try
            {
                if (!_zooKeeperService.Update(id, zooKeeper))
                {
                    return NotFound();
                }
                return Ok("Zookeeper updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
