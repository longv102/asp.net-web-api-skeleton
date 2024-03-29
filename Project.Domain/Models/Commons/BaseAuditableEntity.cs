﻿namespace Project.Domain.Models.Commons
{
    /// <summary>
    /// Auditing properties for all the entities
    /// </summary>
    public abstract class BaseAuditableEntity
    {
        public string? CreatedBy { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public string? ModifiedBy { get; set; }
        
        public DateTime ModifiedAt { get; set; }
    }
}
