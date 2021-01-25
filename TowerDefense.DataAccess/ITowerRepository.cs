using System.Collections.Generic;
using TowerDefense.Logic;

namespace TowerDefense.DataAccess
{
    public interface ITowerRepository
    {
        IEnumerable<TowerInfo> FetchList();
    }
}