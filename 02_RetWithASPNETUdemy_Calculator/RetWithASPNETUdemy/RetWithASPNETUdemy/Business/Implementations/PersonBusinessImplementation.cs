using RetWithASPNETUdemy.Data.Converter.Implementation;
using RetWithASPNETUdemy.Data.VO;
using RetWithASPNETUdemy.Model;
using RetWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RetWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();

        }

        //Metodo responsável por devolver todas as pessoas
        public List<PersonVO> FindAll()
        {
            //converte a entidade para um VO
            return _converter.Parse(_repository.FindAll());
        }

        //Metodo responsável por devolver uma pessoa por RG
        public PersonVO FindById(long id)
        {
            //converte a entidade para um VO
            return _converter.Parse(_repository.FindById(id));
        }

        //Metodo responsável para criar uma nova pessoa
        public PersonVO Create(PersonVO person)
        {
            // nosso repositorio trabalha com entidades e nao com VO
            //logo que o objeto chega ele e um VO e nao da pra persistir na base de dados

            //logo teremos que converter para entidade antes de persistir
            var personEntity = _converter.Parse(person);

            // como aqui ele e entidade entao pode ser persistido
            personEntity = _repository.Create(personEntity);

            // aqui ele converte essa entidade para VO e devolve a resposta
            return _converter.Parse(personEntity);

        }

        //Metodo responsável por atualizar uma pessoa
        public PersonVO Update(PersonVO person)
        {
            // nosso repositorio trabalha com entidades e nao com VO
            //logo que o objeto chega ele e um VO e nao da pra persistir na base de dados

            //logo teremos que converter para entidade antes de persistir
            var personEntity = _converter.Parse(person);

            // como aqui ele é entidade entao pode ser persistido
            personEntity = _repository.Update(personEntity);

            // aqui ele converte essa entidade para VO e devolve a resposta
            return _converter.Parse(personEntity);
        }

        //Metodo responsável por excluir uma pessoa de um documento de identidade
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
