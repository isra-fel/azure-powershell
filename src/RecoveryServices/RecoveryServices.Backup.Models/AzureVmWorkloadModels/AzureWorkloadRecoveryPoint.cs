﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure workload specific recovery point class.
    /// </summary>
    public class AzureWorkloadRecoveryPoint : AzureRecoveryPoint
    {
        public IList<SQLDataDirectory> DataDirectoryPaths { get; set; }

        /// <summary>
        /// Recovery Type information for Recovery point: "Vault", "Snapshot", "Snapshot and Vault" 
        /// </summary>
        public RecoveryPointTier RecoveryPointTier;

        /// <summary>
        /// Recovery point move readiness info
        /// </summary>
        public IDictionary<string, RecoveryPointMoveReadinessInfo> RecoveryPointMoveReadinessInfo;

        /// <summary>
        /// Rehydration expiry time
        /// </summary>
        public DateTime? RehydrationExpiryTime;

        public AzureWorkloadRecoveryPoint()
        {

        }
    }
}