export interface Capacitacion {
  id: string; // Identificador único de la capacitación
  codigoCapacitacion: string; // Código de la capacitación
  nombreCorto: string; // Nombre corto de la capacitación
  nombreLargo: string; // Nombre completo o largo de la capacitación
  descripcion?: string; // Descripción opcional de la capacitación
  enteCapacitador: string; // Entidad que realiza la capacitación
  modalidad: string; // Modalidad: "virtual" o "presencial"
  lugar?: string; // Lugar donde se realizará la capacitación (opcional)
  horario?: string; // Horario de la capacitación (opcional)
  fechaInicioRegistro: Date; // Fecha en que se inicia el registro
  fechaFinRegistro: Date; // Fecha en que finaliza el registro
  estado: string; // Estado de la capacitación: "activo" o "inactivo"
}
