using LanchesMac.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        public readonly AppDbContext _context;
        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;

        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessão acessando o contexto atual(tem que registrar em IServicesCollection)
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o id do carrinho
            string carrinhoId = session.GetString("carrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrnho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto atual e o id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche, int quantidade)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompaId == CarrinhoCompraId);

            //verifica se o carrinho existe e senão existir cria um
            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompaId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };

                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else  //se existir o carrinho com o item então incrementa a quantidade
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompaId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            //verifica se o carrinho é diferente de nulo e se a quanidade for maior que um decrementa
            if (carrinhoCompraItem != null)
            {
                if(carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade --;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
            }
            else  //se 
            {
                _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
            }
            _context.SaveChanges();

            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItens ?? (CarrinhoCompraItens = 
                _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompaId == CarrinhoCompraId)
                        .Include(s => s.Lanche)
                        .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItens
                .Where(carrinho => carrinho.CarrinhoCompaId == CarrinhoCompraId);

            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);

            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal() 
        { 
            var total = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompaId == CarrinhoCompraId)
                .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}
