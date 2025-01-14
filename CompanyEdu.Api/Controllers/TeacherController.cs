﻿using CompanyEdu.Application.Abstraction;
using CompanyEdu.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminActions")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherModel model)
        {
            await _teacherService.CreateAsync(model);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _teacherService.GettByIdAsync(id);

            return Ok(teacher);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _teacherService.GetllAsync();

            return Ok(teachers);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeacherModel model)
        {
            await _teacherService.UpdataAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teacherService.DeleteAsync(id);

            return Ok();
        }
    }
}
