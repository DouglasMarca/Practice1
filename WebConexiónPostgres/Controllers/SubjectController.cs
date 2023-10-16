using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.ModelsSubject;

namespace WebApplication2.ControllersSubjects
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ILogger<SubjectsController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public SubjectsController(
            ILogger<SubjectsController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        //Create: Crear Asignatura
        [Route("Subject")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Subject subject)
        {
            _aplicacionContexto.Subject.Add(subject);
            _aplicacionContexto.SaveChanges();
            return Ok(subject);
        }

        //READ: Obtener lista de Asignaturas
        [Route("Subject")]
        [HttpGet]
        public IEnumerable<Subject> GetSubjects()
        {
            return _aplicacionContexto.Subject.ToList();
        }

        //Update: Modificar asignaturas
        [Route("subject")]
        [HttpPut]
        public IActionResult PutSubject(
            [FromBody] Subject subject)
        {
            _aplicacionContexto.Subject.Update(subject);
            _aplicacionContexto.SaveChanges();
            return Ok(subject);
        }

        //Delete: Eliminar asignaturas
        [Route("subject/{subjectId}")]
        [HttpDelete]
        public IActionResult DeleteSubject(int subjectId)
        {
            _aplicacionContexto.Subject.Remove(
                _aplicacionContexto.Subject.ToList()
                .Where(x => x.IdSubject == subjectId)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(subjectId);
        }
    }
}
