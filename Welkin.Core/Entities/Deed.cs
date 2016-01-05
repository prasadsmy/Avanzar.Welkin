using Avanzar.Welkin.Core.Repositories;
using System;
using System.Collections.Generic;

namespace Avanzar.Welkin.Core.Entities
{
    [EntityType(new string[] {"Deed"})]
    public class Deed : IEventEntity
    {
        private readonly IDataRepository _dataRepo;

        public Deed(IDataRepository dataRepo)
        {
            _dataRepo = dataRepo;
        }
       
        public void UpsertDocument(string document)
        {
            try {
                _dataRepo.UpsertDocument(document);
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("Invalid operation : " + ex.InnerException) ;
            }
        }

    }
}
