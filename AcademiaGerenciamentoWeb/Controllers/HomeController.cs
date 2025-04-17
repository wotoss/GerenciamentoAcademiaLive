using AcademiaGerenciamentoLibary.Domain;
using AcademiaGerenciamentoLibary.DTO;
using AcademiaGerenciamentoLibary.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace AcademiaGerenciamentoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAlunoServices _alunoService;

        public HomeController(
            IAlunoServices alunoService)
        {
            _alunoService = alunoService;
        }
        
        //-> post - ADIÇÃO
        [HttpPost("adicionar-aluno")]
        public async Task<IActionResult> AdicionarAluno([FromBody] AlunoDto alunoDto)
        {
            //service 
            Debugger.Break();
            var alunoAdicionado = await _alunoService.AdicionarAlunoAsync(alunoDto);
            return Ok(new
            {
                mensagem = "Aluno adicionado com sucesso !",
                aluno = alunoAdicionado
            });
        }

        //-> put - Atualizar
        [HttpPut("atualizar-aluno/{id}")]
        public async Task<IActionResult> AtualizarAluno(int id, [FromBody] AlunoDto alunoDto)
        {
            Debugger.Break();
            var alunoAtualizado = await _alunoService.AtualizarAlunoAsync(id, alunoDto);
            if (alunoAtualizado == null)
            {
                return NotFound(new { mensagem = "Aluno não encontrado !" });
            }
            return Ok(new
            {
                mensagem = "Aluno atualizado com sucesso !",
                aluno = alunoAtualizado
            });
        }

    }

}

