import MainCard from '@common/ui-component/cards/main-card.tsx';
import { CapacitacionFormulario } from '../common/capacitacion-formulario.tsx';
import { Row } from '@components/ui-layout/row.tsx';
import { Col } from '@components/ui-layout/col.tsx';
import { useEffect,useState} from "react";
import { useNotification } from '@components/snackbar/use-notification.ts';
import { actualizarCapacitacion } from './api.ts'; // Llamada para actualizar
import { Button } from '@components/button/button.tsx';

interface Capacitacion {
  id: string;
  codigoCapacitacion: string;
  nombreCorto: string;
  nombreLargo: string;
  descripcion: string;
  enteCapacitador: string;
  modalidad: { id: string, name: string };
  lugar: string;
  horario: string;
  fechaInicioRegistro: string;
  fechaFinRegistro: string;
  estado: { id: string, name: string };
}

const nameForm = 'editarCapacitacion';

const Pagina = ({ id }: { id: string }) => {
  const { success } = useNotification();

  const obtenerDatosCapacitacion = async (id: string): Promise<Capacitacion> => {
    const response = await fetch(`/api/v1/capacitacion/${id}`);
    const data = await response.json();
    return data;
  };

  const guardar = async (values: any) => {
    console.log('ACTUALIZAR', values);
    await actualizarCapacitacion({
      id,
      codigoCapacitacion: values.codigoCapacitacion,
      nombreCorto: values.nombreCorto,
      nombreLargo: values.nombreLargo,
      descripcion: values.descripcion,
      enteCapacitador: values.enteCapacitador,
      modalidad: values.modalidad.id,
      lugar: values.lugar,
      horario: values.horario,
      fechaInicioRegistro: values.fechaInicioRegistro,
      fechaFinRegistro: values.fechaFinRegistro,
      estado: values.estado.id,
    });

    success('Capacitación actualizada correctamente');
  };

  const [capacitacion, setCapacitacion] = useState<Capacitacion | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      const data = await obtenerDatosCapacitacion(id);
      setCapacitacion(data);
    };

    fetchData();
  }, [id]);

  if (!capacitacion) return <div>Cargando...</div>;

  return (
    <MainCard xs={{ maxWidth: '1200px' }}>
      <CapacitacionFormulario
        onSubmit={values => guardar(values)}
        nombreFormulario={nameForm}
        initialValues={capacitacion} // Pasa los valores iniciales al formulario
      />
      <Row>
        <Col>
          <Button form={nameForm} type="submit">
            Actualizar
          </Button>
        </Col>
      </Row>
    </MainCard>
  );
};

export default Pagina;
