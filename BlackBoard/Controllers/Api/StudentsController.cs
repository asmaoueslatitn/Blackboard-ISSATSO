using AutoMapper;
using BlackBoard.Core;
using BlackBoard.Core.Dto;
using BlackBoard.Core.Models;
using System.Linq;
using System.Web.Http;

namespace BlackBoard.Controllers.Api
{
    public class StudentsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IHttpActionResult GetStudents()
        {
            var studentsQuery = _unitOfWork.Students.GetStudents();


            var studentDto = studentsQuery.ToList()
                                          .Select(Mapper.Map<Student, StudentDto>);

            return Ok(studentDto);

        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var student = _unitOfWork.Students.GetStudent(id);
            _unitOfWork.Students.Remove(student);
            _unitOfWork.Complete();
            return Ok();
        }

    }
}
