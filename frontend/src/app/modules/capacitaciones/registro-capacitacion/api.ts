import { httpApi } from '../../../http/http-api.ts';


export const RegistroCapacitacion = async (filtros: any) => {
  return httpApi.post('/capacitacion/capacitaciones/registrar', { params: filtros });
};

