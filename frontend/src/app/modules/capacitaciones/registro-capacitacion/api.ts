import { httpApi } from '../../../http/http-api.ts';


export const RegistroCapacitacion = async (filtros: any) => {
  return httpApi.get('/capacitaciones/registrar', { params: filtros });
};

