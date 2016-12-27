using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Flooring.Models
{
    public class TaxRate : ITaxRepository
    {
        public decimal GetTaxRate(State state)
        {
            switch(state)
            {
                case State.AL:
                    return .034M;
                case State.AK:
                    return .034M;
                case State.AR:
                    return .034M;
                case State.AZ:
                    return .034M;
                case State.CA:
                    return .034M;
                case State.CO:
                    return .034M; 
                case State.CT:
                    return .034M;
                case State.DE:
                    return .034M;
                case State.FL:
                    return .034M;
                case State.GA:
                    return .034M;
                case State.HI:
                    return .034M;
                case State.IA:
                    return .034M;
                case State.ID:
                    return .034M;
                case State.IL:
                    return .034M;
                case State.IN:
                    return .034M;
                case State.KS:
                    return .034M;
                case State.KY:
                    return .034M;
                case State.LA:
                    return .034M;
                case State.MA:
                    return .034M;
                case State.MD:
                    return .034M;
                case State.ME:
                    return .034M;
                case State.MI:
                    return .034M;
                case State.MN:
                    return .034M;
                case State.MO:
                    return .034M;
                case State.MS:
                    return .034M;
                case State.MT:
                    return .034M;
                case State.NC:
                    return .034M;
                case State.ND:
                    return .034M;
                case State.NE:
                    return .034M;
                case State.NH:
                    return .034M;
                case State.NJ:
                    return .034M;
                case State.NM:
                    return .034M;
                case State.NV:
                    return .034M;
                case State.NY:
                    return .034M;
                case State.OH:
                    return .034M;
                case State.OK:
                    return .034M;
                case State.OR:
                    return .034M;
                case State.RI:
                    return .034M;
                case State.SC:
                    return .034M;
                case State.SD:
                    return .034M;
                case State.TN:
                    return .034M;
                case State.TX:
                    return .034M;
                case State.UT:
                    return .034M;
                case State.VA:
                    return .034M;
                case State.VT:
                    return .034M;
                case State.WA:
                    return .034M;
                case State.WI:
                    return .034M;
                case State.WV:
                    return .034M;
                case State.WY:
                    return .034M;
                default:
                    return .034M;
            }
            
        }
    }
}
