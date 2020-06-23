using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IToolService
    {
        IEnumerable<Tool> GetAll();
        Tool GetById(int id);
        Tool Create(Tool tool);
        void Update(Tool tool);
        void Delete(int id);
    }

    public class ToolService : IToolService
    {
        private DataContext _context;

        public ToolService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Tool> GetAll()
        {
            return _context.Tools;
        }

        public Tool GetById(int id)
        {
            return _context.Tools.Find(id);
        }

        public Tool Create(Tool tool)
        {
            var tTool = _context.Tools.Find(tool.Id);

            if (tTool == null)
            {
                if (_context.Tools.Any(x => x.Title == tool.Title))
                    throw new AppException("Já existe uma ferramenta de nome: " + tool.Title);                                                           
            }                
            else
            {
                throw new AppException("Ferramenta já cadastrada");
            }


            _context.Tools.Add(tool);
            _context.SaveChanges();


            return tool;
        }

        public void Update(Tool toolParam)
        {
            var tool = _context.Tools.Find(toolParam.Id);

            if (tool == null)
                throw new AppException("Ferramenta não encontrada.");

            if (!string.IsNullOrWhiteSpace(toolParam.Title))
                tool.Title = toolParam.Title;

            if (!string.IsNullOrWhiteSpace(toolParam.Description))
                tool.Description = toolParam.Description;

            if (!string.IsNullOrWhiteSpace(toolParam.Url))
            {
                tool.Url = toolParam.Url;                

                _context.Tools.Update(tool);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var tool = _context.Tools.Find(id);
            if (tool != null)
            {
                _context.Tools.Remove(tool);
                _context.SaveChanges();
            }
        }

    }
}
