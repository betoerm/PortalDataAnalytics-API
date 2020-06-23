using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Tools;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ToolsController : ControllerBase
    {
        private IToolService _toolService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ToolsController(IToolService toolService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _toolService = toolService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(UpdateToolModel model)
        {
            var tool = _mapper.Map<Tool>(model);

            try
            {
                _toolService.Create(tool);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var tools = _toolService.GetAll();
            var model = _mapper.Map<List<ToolModel>>(tools);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tool = _toolService.GetById(id);

            if (tool == null)
                return NotFound("Não encontrado");
            
            return Ok(tool);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateToolModel model)
        {
            var tool = _mapper.Map<Tool>(model);
            tool.Id = id;
            try
            {
                _toolService.Update(tool);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _toolService.Delete(id);
            return Ok();
        }          

    }
}
