﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Pools;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefSwimmingInPool : Dereference<SwimmingInPool>
    {
        protected override DereferenceResult Perform(SwimmingInPool reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            if (Matches(reference, "mContainer", field, objects))
            {
                if (Performing)
                {
                    try
                    {
                        reference.mSim.Posture = null;
                    }
                    catch
                    { }

                    Remove(ref reference.mContainer);
                }
                return DereferenceResult.ContinueIfReferenced;
            }

            return DereferenceResult.Failure;
        }
    }
}
