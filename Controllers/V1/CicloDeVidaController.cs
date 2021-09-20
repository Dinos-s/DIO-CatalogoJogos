using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class CicloDeVidaController : ControllerBase
    {
        public readonly IExemploSingleton _exemploSingleton1;
        public readonly IExemploSingleton _exemploSingleton2;

        public readonly IExemploScoped _exemploScoped1;
        public readonly IExemploScoped _exemploScoped2;

        public readonly IExemploTransient _exemploTrasient1;
        public readonly IExemploTransient _exemploTrasient2;

        public CicloDeVidaController(IExemploSingleton exemploSingleton1,
        IExemploSingleton exemploSingleton2,
        IExemploScoped exemploScoped1,
        IExemploScoped exemploScoped2,
        IExemploTransient exemploTrasient1,
        IExemploTransient exemploTrasient2)
        {
            _exemploSingleton1 = exemploSingleton1;
            _exemploSingleton2 = exemploSingleton2;
            _exemploScoped1 = exemploScoped1;
            _exemploScoped2 = exemploScoped2;
            _exemploTrasient1 = exemploTrasient1;
            _exemploTrasient2 = exemploTrasient2;
        }

        [HttpGet]
        public Task<string> Get()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Singleton 1: {_exemploSingleton1.Id}");
            stringBuilder.AppendLine($"Singleton 2: {_exemploSingleton2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Scoped 1: {_exemploScoped1.Id}");
            stringBuilder.AppendLine($"Scoped 2: {_exemploScoped2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Transient 1: {_exemploTrasient1.Id}");
            stringBuilder.AppendLine($"Transient 2: {_exemploTrasient2.Id}");

            return Task.FromResult(stringBuilder.ToString());
        }

    }

    public interface IExemploGeral
    {
        public Guid Id { get; }
    }

    public interface IExemploSingleton : IExemploGeral
    { }

    public interface IExemploScoped : IExemploGeral
    { }

    public interface IExemploTransient : IExemploGeral
    { }

    public class ExemploCicloDeVida : IExemploSingleton, IExemploScoped, IExemploTransient
    {
        private readonly Guid _guid;

        public ExemploCicloDeVida()
        {
            _guid = Guid.NewGuid();
        }

        public Guid Id => _guid;
    }
}
