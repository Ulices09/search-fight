using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Presenter.Interfaces
{
    public interface ISearchFightPresenter
    {
        Task SearchFight(string[] programmingLanguages);
    }
}
