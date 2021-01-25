using ApiContatos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiContatos.Controllers
{
    public class PessoasController : ApiController
    {

        public IHttpActionResult GetTodosContatos()
        {
            IList<Pessoa> pessoas = null;

            using (var ctx = new AppDbContext())
            {
                pessoas = ctx.Pessoas.ToList();
            }

            if (pessoas.Count == 0)
            {
                return NotFound();
            }
            return Ok(pessoas);
        }


        
        public IHttpActionResult GetContatoPorId(int? id)
        {
            if (id == null)
                return BadRequest("O Id do contato é inválido");

            Pessoa pessoa = null;

            using (var ctx = new AppDbContext())
            {
                pessoa = ctx.Pessoas.Where(c=> c.PessoaId == id).FirstOrDefault();
            }

            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }


       
        public IHttpActionResult PostNovoContato(PessoaDTO contato)
        {
             if(string.IsNullOrEmpty(contato.Nome) ||
                string.IsNullOrEmpty(contato.Sobrenome) ||
                string.IsNullOrEmpty(contato.Nacionalidade) ||
                string.IsNullOrEmpty(contato.CEP) ||
                string.IsNullOrEmpty(contato.CPF) ||
                string.IsNullOrEmpty(contato.Estado) ||
                string.IsNullOrEmpty(contato.Cidade) ||
                string.IsNullOrEmpty(contato.Logradouro) ||
                string.IsNullOrEmpty(contato.Email) ||
                string.IsNullOrEmpty(contato.Telefone))
            {
                return BadRequest("Todos os dados são de preenchimento obrigatório");
            }
                   

            if (contato.CEP != null && contato.CPF != null && contato.Telefone != null)
            {
                contato.CEP = contato.CEP.Replace("-", "").Trim();
                contato.CPF = contato.CPF.Replace(".", "").Replace("-", "").Trim();
                contato.Telefone = contato.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
            }

            var retornoCpf = Funcoes.funcoes.ValidarCpf(contato.CPF);
            if (retornoCpf == false)
            {
                return BadRequest("cpf digitado inválido");
            }

            using (var ctx = new AppDbContext())
            {
                //VERIFICA SE JA TEM UM CPF CADASTRADO
                var retorno = ctx.Pessoas.Where(c => c.CPF == contato.CPF).Any();
                if (retorno == true) { return BadRequest("cpf já cadastrado com esse número"); }


                ctx.Pessoas.Add(new Pessoa()
                {
                    Nome = contato.Nome,
                    Sobrenome = contato.Sobrenome,
                    Nacionalidade = contato.Nacionalidade,
                    CEP = contato.CEP,
                    CPF = contato.CPF,
                    Estado = contato.Estado,
                    Cidade = contato.Cidade,
                    Logradouro = contato.Logradouro,
                    Email = contato.Email,
                    Telefone = contato.Telefone
                });

                ctx.SaveChanges();
            }
            return Ok(contato);
        }

        public IHttpActionResult Put(Pessoa contato)
        {
            if (string.IsNullOrEmpty(contato.Nome) ||
                string.IsNullOrEmpty(contato.Sobrenome) ||
                string.IsNullOrEmpty(contato.Nacionalidade) ||
                string.IsNullOrEmpty(contato.CEP) ||
                string.IsNullOrEmpty(contato.CPF) ||
                string.IsNullOrEmpty(contato.Estado) ||
                string.IsNullOrEmpty(contato.Cidade) ||
                string.IsNullOrEmpty(contato.Logradouro) ||
                string.IsNullOrEmpty(contato.Email) ||
                string.IsNullOrEmpty(contato.Telefone))
            {
                return BadRequest("Todos os dados são de preenchimento obrigatório");
            }


            if (contato.CEP != null && contato.CPF != null && contato.Telefone != null)
            {
                contato.CEP = contato.CEP.Replace("-", "").Trim();
                contato.CPF = contato.CPF.Replace(".", "").Replace("-", "").Trim();
                contato.Telefone = contato.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Trim();
            }

            var retornoCpf = Funcoes.funcoes.ValidarCpf(contato.CPF);
            if (retornoCpf == false)
            {
                return BadRequest("cpf digitado inválido");
            }

            using (var ctx = new AppDbContext())
            {
                               
                var contatosSelecionados = ctx.Pessoas.Where(c => c.PessoaId == contato.PessoaId)
                    .FirstOrDefault<Pessoa>();

                if (contatosSelecionados != null)
                {
                    contatosSelecionados.Nome = contato.Nome;
                    contatosSelecionados.Sobrenome = contato.Sobrenome;
                    contatosSelecionados.Nacionalidade = contato.Nacionalidade;
                    contatosSelecionados.CEP = contato.CEP;
                    contatosSelecionados.CPF = contato.CPF;
                    contatosSelecionados.Estado = contato.Estado;
                    contatosSelecionados.Cidade = contato.Cidade;
                    contatosSelecionados.Logradouro = contato.Logradouro;
                    contatosSelecionados.Email = contato.Email;
                    contatosSelecionados.Telefone = contato.Telefone;

                    ctx.Entry(contatosSelecionados).State = EntityState.Modified;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok($"Contato {contato.Nome} atualizado com sucesso");
        }

        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest("Dados inválidos");

            using (var ctx = new AppDbContext())
            {
                var contatoSelecionado = ctx.Pessoas.Where(c => c.PessoaId == id)
                                         .FirstOrDefault<Pessoa>();

                if (contatoSelecionado != null)
                {
                    ctx.Entry(contatoSelecionado).State = EntityState.Deleted;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok($"Contato {id} foi deletado com sucesso");
            }
        }
    }
}
