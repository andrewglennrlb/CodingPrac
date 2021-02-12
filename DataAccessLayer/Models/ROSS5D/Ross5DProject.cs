using System;
using System.Collections.Generic;
using System.Text;
using RLBPulse.System.DAL.Entities;

namespace DAL.Models.ROSS5D
{
    public class Ross5DProject
    {
        private List<Parameter> _parameters;
        private List<Measurements> _measurements;
        private List<BuildingClassEntity> _buildingClasses;
        private List<Location> _locations;

        public List<Parameter> Parameters
        {
            get => _parameters;
            set => _parameters = value;
        }

        public List<Measurements> Measurements
        {
            get => _measurements;
            set => _measurements = value;
        }

        public List<BuildingClassEntity> BuildingClasses
        {
            get => _buildingClasses;
            set => _buildingClasses = value;
        }

        public List<Location> Locations
        {
            get => _locations;
            set => _locations = value;
        }
    }
}
