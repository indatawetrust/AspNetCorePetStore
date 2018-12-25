/*
 * Swagger Petstore
 *
 * This is a sample server Petstore server.  You can find out more about Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).  For this sample, you can use the api key `special-key` to test the authorization filters.
 *
 * OpenAPI spec version: 1.0.0
 * Contact: apiteam@swagger.io
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;
using IO.Swagger.Models;
using IO.Swagger.Data;
using Microsoft.EntityFrameworkCore;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class UserApiController : Controller
    { 
        private readonly DataContext _context;

        public UserApiController(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Create user
        /// </summary>
        /// <remarks>This can only be done by the logged in user.</remarks>
        /// <param name="body">Created user object</param>
        /// <response code="0">successful operation</response>
        [HttpPost]
        [Route("/v2/user")]
        [ValidateModelState]
        [SwaggerOperation("CreateUser")]
        public  IActionResult CreateUser([FromBody]User body)
        { 
            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0);
			_context.Users.Add(body);
			_context.SaveChanges();
			return StatusCode(201);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        
        /// <param name="body">List of user object</param>
        /// <response code="0">successful operation</response>
        [HttpPost]
        [Route("/v2/user/createWithArray")]
        [ValidateModelState]
        [SwaggerOperation("CreateUsersWithArrayInput")]
        public virtual IActionResult CreateUsersWithArrayInput([FromBody]List<User> body)
        { 
            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        
        /// <param name="body">List of user object</param>
        /// <response code="0">successful operation</response>
        [HttpPost]
        [Route("/v2/user/createWithList")]
        [ValidateModelState]
        [SwaggerOperation("CreateUsersWithListInput")]
        public virtual IActionResult CreateUsersWithListInput([FromBody]List<User> body)
        { 
            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <remarks>This can only be done by the logged in user.</remarks>
        /// <param name="username">The name that needs to be deleted</param>
        /// <response code="400">Invalid username supplied</response>
        /// <response code="404">User not found</response>
        [HttpDelete]
        [Route("/v2/user/{username}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromRoute][Required]string username)
        { 
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

			var user = await _context.Users.FirstAsync(b => b.Username == username);
			_context.Users.Remove(user);
			await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        /// <summary>
        /// Get user by user name
        /// </summary>
        
        /// <param name="username">The name that needs to be fetched. Use user1 for testing. </param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid username supplied</response>
        /// <response code="404">User not found</response>
        [HttpGet]
        [Route("/v2/user/{username}")]
        [ValidateModelState]
        [SwaggerOperation("GetUserByName")]
        [SwaggerResponse(statusCode: 200, type: typeof(User), description: "successful operation")]
        public async Task<IActionResult> GetUserByName([FromRoute][Required]string username)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(User));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            var user = await _context.Users.FirstAsync(b => b.Username == username);

            return Json(user);
        }

        /// <summary>
        /// Logs user into the system
        /// </summary>
        
        /// <param name="username">The user name for login</param>
        /// <param name="password">The password for login in clear text</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid username/password supplied</response>
        [HttpGet]
        [Route("/v2/user/login")]
        [ValidateModelState]
        [SwaggerOperation("LoginUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(string), description: "successful operation")]
        public async Task<IActionResult> LoginUser([FromQuery][Required()]string username, [FromQuery][Required()]string password)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(string));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            var user = await _context.Users.FirstAsync(b => b.Username == username && b.Password == password);

            if (user != null) {

                user.UserStatus = 1;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return StatusCode(200);

            } else {

                return StatusCode(400);

            }
            

        }

        /// <summary>
        /// Logs out current logged in user session
        /// </summary>
        
        /// <response code="0">successful operation</response>
        [HttpGet]
        [Route("/v2/user/logout")]
        [ValidateModelState]
        [SwaggerOperation("LogoutUser")]
        public virtual IActionResult LogoutUser()
        { 
            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Updated user
        /// </summary>
        /// <remarks>This can only be done by the logged in user.</remarks>
        /// <param name="username">name that need to be updated</param>
        /// <param name="body">Updated user object</param>
        /// <response code="400">Invalid user supplied</response>
        /// <response code="404">User not found</response>
        [HttpPut]
        [Route("/v2/user/{username}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromRoute][Required]string username, [FromBody]User body)
        { 
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            
			var user = await _context.Users.FirstAsync(b => b.Username == username);

            if (user != null) {
            
                user.Username = body.Username;
                user.Password = body.Password;
                user.FirstName = body.FirstName;
                user.LastName = body.LastName;
                user.Email = body.Email;
                user.Phone = body.Phone;
                user.UserStatus = body.UserStatus;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return StatusCode(204);

            } else {
                
                return StatusCode(400);

            }

        }
    }
}
