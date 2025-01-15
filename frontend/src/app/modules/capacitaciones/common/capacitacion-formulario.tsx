import {
  ComboBox,
  DatePicker,
  HookForm,
  InputText,
} from '@components/form';
import { Grid } from '@mui/material';
import * as yup from 'yup';
import TimePickerComponent from '@components/form/date-time/time-picker';
import { Row } from '@components/ui-layout/row.tsx';
import { Col } from '@components/ui-layout/col.tsx';

export const modalidades = [
  { name: 'Virtual', id: 'virtual' },
  { name: 'Presencial', id: 'presencial' },
  { name: 'Híbrido', id: 'hibrido' },
];

const estados = [
  { name: 'Disponible', id: 'disponible' },
  { name: 'No Disponible', id: 'no disponible' },
];

const validations = yup.object({
  nombreCorto: yup.string().required('Campo requerido'),
  nombreLargo: yup.string().required('Campo requerido'),
  descripcion: yup.string().required('Campo requerido'),
  enteCapacitador: yup.string().required('Campo requerido'),
  modalidad: yup
    .object()
    .shape({
      id: yup.string().required('Seleccione una opción válida'),
      name: yup.string(),
    })
    .required('Campo requerido'),
  lugar: yup.string().nullable(),
  horario: yup.string().nullable(),
  fechaInicioRegistro: yup
    .date()
    .min(new Date(), 'La fecha de inicio debe ser posterior a la fecha actual')
    .required('Campo requerido'),
  fechaFinRegistro: yup
    .date()
    .min(
      yup.ref('fechaInicioRegistro'),
      'La fecha de fin debe ser posterior a la fecha de inicio'
    )
    .required('Campo requerido'),
  estado: yup
    .object()
    .shape({
      id: yup.string().required('Seleccione una opción válida'),
      name: yup.string(),
    })
    .required('Campo requerido'),
});

interface Props {
  nombreFormulario: string;
  onSubmit: (values: any) => void;
  initialValues?: any; // Agregar soporte para valores iniciales
}

export const CapacitacionFormulario = ({
                                         nombreFormulario,
                                         onSubmit,
                                         initialValues = {}, // Valores iniciales con predeterminado vacío
                                       }: Props) => {
  const guardar = (values: any) => {
    onSubmit(values);
  };

  return (
    <HookForm
      nameForm={nombreFormulario}
      onSubmit={guardar}
      validations={validations}
      defaultValues={initialValues} // Pasar los valores iniciales al formulario
    >
      {() => {
        return (
          <Grid container spacing={3}>
            <Row>
              <Col>
                <InputText label="Nombre Corto" name="nombreCorto" />
              </Col>
              <Col>
                <InputText label="Nombre Largo" name="nombreLargo" />
              </Col>
            </Row>
            <Row>
              <Col>
                <InputText
                  label="Descripción"
                  name="descripcion"
                  multiline
                  rows={3}
                />
              </Col>
              <Col>
                <InputText label="Ente Capacitador" name="enteCapacitador" />
              </Col>
            </Row>
            <Row>
              <Col>
                <ComboBox
                  label="Modalidad"
                  name="modalidad"
                  items={modalidades}
                  placeholder="Seleccione modalidad"
                />
              </Col>
              <Col>
                <InputText label="Lugar" name="lugar" />
              </Col>
            </Row>
            <Row>
              <Col>
                <TimePickerComponent label="Horario" name="horario" />
              </Col>
              <Col>
                <DatePicker
                  label="Fecha Inicio Registro"
                  name="fechaInicioRegistro"
                  placeholder="Seleccione fecha de inicio"
                />
              </Col>
            </Row>
            <Row>
              <Col>
                <DatePicker
                  label="Fecha Fin Registro"
                  name="fechaFinRegistro"
                  placeholder="Seleccione fecha de fin"
                />
              </Col>
              <Col>
                <ComboBox
                  label="Estado"
                  name="estado"
                  items={estados}
                  placeholder="Seleccione estado"
                />
              </Col>
            </Row>
          </Grid>
        );
      }}
    </HookForm>
  );
};
