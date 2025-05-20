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

        //[HttpPost("adicionar-aluno")]
        //public async Task<IActionResult> AdicionarAluno([FromBody] AlunoDto alunoDto)
        //{
        //    Debugger.Break();
        //    //Dto esta recebendo esta valido conforme as anotações
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(new
        //        {
        //            mensagem = "Dados inválidos ! verifique os campos enviados...",
        //            erros = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
        //        });
        //    }

        //    try
        //    {
        //        //service 
        //        Debugger.Break();
        //        var alunoAdicionado = await _alunoService.AdicionarAlunoAsync(alunoDto);
        //        //quero fazer uma validação
        //        if (alunoAdicionado == null)
        //        {
        //            return Conflict(new
        //            {
        //                mensagem = "Aluno já existe na base de dados"
        //            });
        //        }

        //        return CreatedAtRoute("ObterAlunoPorId", new { id = alunoAdicionado.ID }, new
        //        {
        //            mensagem = "Aluno adicionado com sucesso !",
        //            aluno = alunoAdicionado

        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        //Ocorrendo um erro que eu não preví no meu software
        //        return StatusCode(500, new
        //        {
        //            mensagem = "Erro interno ao tentar adicionar aluno",
        //            erro = ex.Message,
        //        });

        //    }

        //}

        //inicio - coloquei agora - 06-05-25

        [HttpPost("adicionar-aluno")]
        public async Task<IActionResult> AdicionarAluno([FromBody] AlunoDto alunoDto)
        {
            Debugger.Break();
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    mensagem = "Dados inválidos. Verifique os campos enviados.",
                    erros = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            try
            {
                var alunoAdicionado = await _alunoService.AdicionarAlunoAsync(alunoDto);

                if (alunoAdicionado == null)
                {
                    return Conflict(new { mensagem = "Aluno já existe na base de dados." });
                }

                return CreatedAtRoute("ObterAlunoPorId", new { id = alunoAdicionado.ID }, new
                {
                    mensagem = "Aluno e pagamentos adicionados com sucesso!",
                    aluno = alunoAdicionado 

                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensagem = "Erro interno ao tentar adicionar o aluno.",
                    erro = ex.Message
                });
            }
        }


        //fim


        [HttpGet("{id}", Name = "ObterAlunoPorId")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var aluno = await _alunoService.ObterPorIdAsync(id);
            if (aluno == null)
                return NotFound(new { mensagem = "Aluno não encontrado!" });

            return Ok(aluno);
        }

        //-> put - Atualizar
        [HttpPut("atualizar-aluno/{id}")]
        public async Task<IActionResult> AtualizarAluno(int id, [FromBody] AlunoDto alunoDto)
        {
            Debugger.Break();
            if (!ModelState.IsValid)
            {
                return BadRequest(new 
                {
                    mensagem = "Dados inválidos, verifique os campos enviados...",
                    erros = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                });
            }
            try
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
            catch (Exception execessao)
            {
                return StatusCode(500, new
                {
                    mensagem = "Erro interno ao tentar atualizar o aluno...",
                    erro = execessao.Message
                });
            }
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
            //recurso excluido - sem corpo - StatusCode: 204
            return NoContent();

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

        //JsonResult ListarTodos
        [HttpGet("listar-alunos")]
        public async Task<JsonResult> ListarTodosAlunos()
        {
            try
            {
                //melhor do mundos
                var alunos = await _alunoService.ObterTodosAlunosAsync();
                if (alunos == null || !alunos.Any())
                {
                    Response.StatusCode = 204; //NoContent
                    return new JsonResult(new
                    {
                        status = 204,
                        sucesso = true,
                        mensagem = "Nenhum aluno encontrado.",
                        dados = new object[] { }
                    });
                }
                Response.StatusCode = 200; //Ok
                return new JsonResult(new
                {
                    status = 200,
                    sucesso = true,
                    mensagem = "Lista de alunos obtida com sucesso...",
                    dados = alunos
                });
            }
            catch (Exception execessao)
            {
                //erro inesperado ou personalizado 
                Response.StatusCode = 500; //Erro Servidor Interno
                return new JsonResult(new
                {
                    status = 500,
                    sucesso = false,
                    mensagem = "Erro ao buscar os alunos...",
                    erro = execessao.Message

                });
            }
        }

    }

}

