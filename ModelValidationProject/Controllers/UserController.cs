using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims; 

namespace ModelValidationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<Staff> StaffList = new List<Staff>() //creating the static list for staffs
        {
            new Staff   //member of list as instance of class
            {
                    Id =1,
                    Name = "Deny",
                    Lastname = "Sellen",
                    DateOfBirth = new System.DateTime(1989,01,01),
                    Email="deny@gmail.com",
                    PhoneNumber ="+90555443366",
                    Salary = 4450
            },
            new Staff   // another member of list as instance of class
            {
                    Id =2,
                    Name = "Chiara",
                    Lastname = "Leo",
                    DateOfBirth = new System.DateTime(2000,01,01),
                    Email="chiara@gmail.com",
                    PhoneNumber ="+905409993330",
                    Salary = 4000
            }

        };
        [HttpGet]
        public List<Staff> GetUsers()
        {
            var users = StaffList.OrderBy(x => x.Id).ToList<Staff>(); //validation 
            return StaffList;
        }

        [HttpGet("{id}")]

        public Staff GetById(int id)                                //validation
        {

            var user = StaffList.Where(Staff => Staff.Id == id).SingleOrDefault();
            return user;
        }

        [HttpPost]
        public IActionResult AddStaff([FromBody] Staff newStaff)    //validation
        {
            var staff = StaffList.SingleOrDefault(x => x.Name == new Staff().Name);//checking the existing Staff before creating

            if (staff is not null)
            {
                return BadRequest();
            }
            StaffList.Add(newStaff); //if staff is null then add the newStaff to Stafflist

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStaff(int id, [FromBody] Staff updatedStaff) //update method and updates every field of the member.
        {
            var  staff= StaffList.SingleOrDefault(x => x.Id == id);
           
            if(staff is null)
            {
                return BadRequest();
            }
            
            staff.Name = updatedStaff.Name != default ? updatedStaff.Name : updatedStaff.Name;
            staff.Lastname= updatedStaff.Lastname!= default ? updatedStaff.Lastname : updatedStaff.Lastname;
            staff.PhoneNumber=updatedStaff.PhoneNumber!=default ? updatedStaff.PhoneNumber : updatedStaff.PhoneNumber;
            staff.DateOfBirth=updatedStaff.DateOfBirth!= default ? updatedStaff.DateOfBirth : updatedStaff.DateOfBirth;
            staff.Email=updatedStaff.Email!=default ? updatedStaff.Email : updatedStaff.Email;
            staff.Salary=updatedStaff.Salary!=default ? updatedStaff.Salary : updatedStaff.Salary;
            staff.Id=updatedStaff.Id!=default ? updatedStaff.Id : updatedStaff.Id;

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletedStaff(int id)
        {
            
            var staff=StaffList.SingleOrDefault(x => x.Id == id);//validation for checking if there is same id in list
            if (staff == null)
            {
                return BadRequest();
            }
            StaffList.Remove(staff);// if its null, return badrequest, if not remove the item with Remove Method.
            return Ok();
        }

    }
}
