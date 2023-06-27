using apiders.Data;
using apiders.DTOS;
using apiders.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace apiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        private readonly MockCOmmanderRepo _rep;
        private readonly IMapper _mapper;

        public DefaultController(MockCOmmanderRepo rep,IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Commad>> GetAllCommand()
        {
            var com = _rep.GetCommads();
             return Ok(_mapper.Map<IEnumerable<CommadReadDto>>(com));


        }
        [HttpGet("{id}")]
        public ActionResult <CommadReadDto> GetCommandby(int id)
        {
            if (id == null) return NotFound();
            var co = _rep.GetCommad(id);
           
           
            return Ok(_mapper.Map<CommadReadDto>(co));
        }

        [HttpPost]
        public ActionResult <CommadCreateDto> create(CommadCreateDto cm)
        {
            if (cm == null) return NotFound();
            var com = _mapper.Map<Commad>(cm);
            _rep.Create(com);
            _rep.SaveChanges();

            var nese = _mapper.Map<CommadReadDto>(com);
            return Ok(nese);
           
        }

        [HttpPut]
        public ActionResult<CommadUpdataDto> update(CommadUpdataDto cm)
        {
            var data = _rep.GetCommad(cm.Id);

            if (data == null) return NotFound();

            //data.Platform = cm.Platform;
            //data.Line = cm.Line;
            //data.HowTo = cm.HowTo;


            /*  var son =*/
            _mapper.Map(cm, data);
            //_mapper.Map(data, Commad);
            //_mapper.Map<Commad>(data);
            //_rep.update(son);
            _rep.SaveChanges();
            return Ok();


        }
        [HttpDelete]
        public ActionResult<Commad> delete(int id)
        {
            _rep.getDelete(id);
            _rep.SaveChanges();
            return Ok();
        }
    }
}
