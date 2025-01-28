import { httpApi } from '../../../http/http-api.ts';


export const RegistroCapacitacion = async (filtros: any) => {
  return httpApi.post('', { params: filtros });
};

