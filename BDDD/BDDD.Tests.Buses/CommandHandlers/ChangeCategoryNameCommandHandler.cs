using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Commands;
using BDDD.Repository;
using BDDD.Tests.Buses.Commands;

namespace BDDD.Tests.Buses.CommandHandlers
{
    public class ChangeCategoryNameCommandHandler : CommandHandler<ChangeCategoryNameCommand>
    {
        public override bool Handle(ChangeCategoryNameCommand message)
        {
            using (IDomainRepository repository = DomainRepository)
            {
                //repository.Get<
                //var cust = repository.Get<SourcedCustomer>(message.CategoryID);
                //repository.Save<SourcedCustomer>(cust);
                //repository.Commit();
                //return true;
                return true;
            }
        }
    }
}
