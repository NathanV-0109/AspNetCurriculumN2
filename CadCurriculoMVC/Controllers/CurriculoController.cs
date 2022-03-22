using CadCurriculoMVC.DAO;
using CadCurriculoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadCurriculoMVC.Controllers
{
    public class CurriculoController : Controller
    {
        public IActionResult Index()
        {
            try
            {                   
                var dao = new PessoaDAO();
                var lista = dao.Listar();
                return View(lista);
            }

            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }

        public IActionResult Create()
        {
            AllInformationViewModel allInformationViewModel = new AllInformationViewModel();
            allInformationViewModel.Pessoa = new PessoaViewModel();
            allInformationViewModel.Experiencia = new ExperienciaViewModel();
            allInformationViewModel.Formacao = new FormacaoViewModel();
            allInformationViewModel.Idioma = new IdiomaViewModel();
            return View("FormCadastro", allInformationViewModel);
        }

        public IActionResult Edit(int id)
        {
            PessoaDAO pessoaDAO = new PessoaDAO();
            ExperienciaDAO experienciaDAO = new ExperienciaDAO();
            IdiomaDAO idiomaDAO = new IdiomaDAO();
            FormacaoDAO formacaoDAO = new FormacaoDAO();
            if (pessoaDAO.Consultar(id) != null)
            {
                AllInformationViewModel allInformationViewModel = new AllInformationViewModel();
                allInformationViewModel.Pessoa = pessoaDAO.Consultar(id);
                allInformationViewModel.Experiencia = experienciaDAO.Consultar(id);
                allInformationViewModel.Formacao = formacaoDAO.Consultar(id);
                allInformationViewModel.Idioma = idiomaDAO.Consultar(id);
                return View("FormCadastro", allInformationViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult Delete(int id)
        {
            PessoaDAO pessoaDAO = new PessoaDAO();
            ExperienciaDAO experienciaDAO = new ExperienciaDAO();
            IdiomaDAO idiomaDAO = new IdiomaDAO();
            FormacaoDAO formacaoDAO = new FormacaoDAO();
            experienciaDAO.Delete(id);
            idiomaDAO.Delete(id);
            formacaoDAO.Delete(id);
            pessoaDAO.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ViewCurriculum(int id)
        {
            PessoaDAO pessoaDAO = new PessoaDAO();
            ExperienciaDAO experienciaDAO = new ExperienciaDAO();
            IdiomaDAO idiomaDAO = new IdiomaDAO();
            FormacaoDAO formacaoDAO = new FormacaoDAO();
           
            AllInformationViewModel allInformationViewModel = new AllInformationViewModel();
            allInformationViewModel.Pessoa = pessoaDAO.Consultar(id);
            allInformationViewModel.Experiencia = experienciaDAO.Consultar(id);
            allInformationViewModel.Formacao = formacaoDAO.Consultar(id);
            allInformationViewModel.Idioma = idiomaDAO.Consultar(id);
            return View("CurriculumVitae", allInformationViewModel);
        }

        public IActionResult Salvar(PessoaViewModel p, FormacaoViewModel f, ExperienciaViewModel e, IdiomaViewModel i)
        {
            try
            {
                var daoPessoa = new PessoaDAO();
                var daoFormacao = new FormacaoDAO();
                var daoExperiencia = new ExperienciaDAO();
                var daoIdioma = new IdiomaDAO();
                if(daoPessoa.Consultar(p.Id) != null)
                {
                    daoPessoa.Update(p);
                    daoFormacao.Update(p, f);
                    daoExperiencia.Update(p, e);
                    daoIdioma.Update(p, i);
                    return RedirectToAction("Index");
                }
                else
                {
                    daoPessoa.Insert(p);
                    daoFormacao.Insert(p, f);
                    daoExperiencia.Insert(p, e); 
                    daoIdioma.Insert(p, i);
                    return RedirectToAction("Index");
                }
                
            }

            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }
    }
}
