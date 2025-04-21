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
    //[ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAlunoServices _alunoService;

        public HomeController(
            IAlunoServices alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost("adicionar-aluno")]
        public async Task<IActionResult> AdicionarAluno([FromBody] AlunoDto alunoDto)
        {
            Debugger.Break();
            //Dto esta recebendo esta valido conforme as anotações
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    mensagem = "Dados inválidos ! verifique os campos enviados...",
                    erros = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            try
            {
                //service 
                Debugger.Break();
                var alunoAdicionado = await _alunoService.AdicionarAlunoAsync(alunoDto);
                //quero fazer uma validação
                if (alunoAdicionado == null)
                {
                    return Conflict(new
                    {
                        mensagem = "Aluno já existe na base de dados"
                    });
                }

                return CreatedAtRoute("ObterAlunoPorId", new { id = alunoAdicionado.ID }, new
                {
                    mensagem = "Aluno adicionado com sucesso !",
                    aluno = alunoAdicionado

                });
            }
            catch (Exception ex)
            {
                //Ocorrendo um erro que eu não preví no meu software
                return StatusCode(500, new
                {
                    mensagem = "Erro interno ao tentar adicionar aluno",
                    erro = ex.Message,
                });
                
            }
            
        }


        [HttpGet("{id}", Name = "ObterAlunoPorId")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var aluno = await _alunoService.ObterPorIdAsync(id);
            if (aluno == null)
                return NotFound(new { mensagem = "Aluno não encontrado!" });

            return Ok(aluno);
        }




        //fim - novo teste

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



        //Delete
        [HttpDelete("excluir-aluno/{id}")]
        public async Task<IActionResult> ExcluirAluno(int id)
        {
            Debugger.Break();
            var excluir = await _alunoService.ExcluirAlunoAsync(id);

            if (!excluir)
            {
                return NotFound(new { mensagem = "Aluno não encontrado !" });
            }
            return Ok(new { mensagem = "Aluno excluido com sucesso !" });

        }



        //Consultar
        [HttpGet("consultar-aluno/{id}")]
        public async Task<IActionResult> ConsultarAluno(int id)
        {
            Debugger.Break();
            var aluno = await _alunoService.ConsultarAlunoAsync(id);

            if (aluno == null)
            {
                return NotFound(new { mensagem = "Aluno não encontrado" });
            }
            Debugger.Break();
            return Ok(new
            {
                
                mensagem = "Aluno encontrado com sucesso!",
                aluno
            });
        }
 
    }

}

