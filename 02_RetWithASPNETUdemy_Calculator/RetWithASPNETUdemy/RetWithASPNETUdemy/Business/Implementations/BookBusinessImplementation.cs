using RetWithASPNETUdemy.Data.Converter.Implementation;
using RetWithASPNETUdemy.Data.VO;
using RetWithASPNETUdemy.Model;
using RetWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RetWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        public BookVO Create(BookVO book)
        {
            // nosso repositorio trabalha com entidades e nao com VO
            //logo que o objeto chega ele e um VO e nao da pra persistir na base de dados

            //logo teremos que converter para entidade antes de persistir
            var bookEntity = _converter.Parse(book);

            // como aqui ele e entidade entao pode ser persistido
            bookEntity = _repository.Create(bookEntity);

            // aqui ele converte essa entidade para VO e devolve a resposta
            return _converter.Parse(bookEntity);
        }

        public BookVO Update(BookVO book)
        {
            // nosso repositorio trabalha com entidades e nao com VO
            //logo que o objeto chega ele e um VO e nao da pra persistir na base de dados

            //logo teremos que converter para entidade antes de persistir
            var bookEntity = _converter.Parse(book);

            // como aqui ele e entidade entao pode ser persistido
            bookEntity = _repository.Update(bookEntity);

            // aqui ele converte essa entidade para VO e devolve a resposta
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        
    }
}
