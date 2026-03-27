using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoVendas.Interfaces
{
    interface ISubject 
    {
        void Add(IObserver observer);
        void Remove(IObserver observer);
        void Notify();
    }
}
