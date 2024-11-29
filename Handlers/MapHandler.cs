using AutoMapper;
using DIRS21Interview.Models;
using System;

namespace DIRS21Interview.Handlers
{
    public class MapHandler
    {
        private readonly IMapper _mapper;

        public MapHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public object Map(object data, string sourceType, string targetType)
        {
            try
            {
                var source = Type.GetType(sourceType);
                var target = Type.GetType(targetType);

                if (source == null || target == null)
                {
                    throw new Exception($"Invalid mapping types");
                }

                if (source == typeof(ReservationInternalModel) && target == typeof(ReservationPartnerModel))
                {
                    return _mapper.Map<ReservationPartnerModel>((ReservationInternalModel)data);
                }

                if (source == typeof(ReservationPartnerModel) && target == typeof(ReservationInternalModel))
                {
                    return _mapper.Map<ReservationInternalModel>((ReservationPartnerModel)data);
                }

                var result = _mapper.Map(data, source, target);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error mapping : {ex.Message}", ex);
            }
        }
    }
}
