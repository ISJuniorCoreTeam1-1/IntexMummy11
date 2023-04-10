using Microsoft.AspNetCore.Mvc;
using IntexMummy11.DataAccess;
using IntexMummy11.Models;
using System;
using System.Collections.Generic;

namespace IntexMummy11.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public UsersController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dataAccessProvider.GetUserRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                user.username = obj.ToString();
                _dataAccessProvider.AddUserRecord(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public User Details(string username)
        {
            return _dataAccessProvider.GetUserSingleRecord(username);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateUserRecord(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string username)
        {
            var data = _dataAccessProvider.GetUserSingleRecord(username);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteUserRecord(username);
            return Ok();
        }
    }
}