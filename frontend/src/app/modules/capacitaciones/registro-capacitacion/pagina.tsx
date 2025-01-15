import { useNotification } from '@components/snackbar/use-notification.ts';
import { httpApi } from '../../../http/http-api.ts';
import { usePaginate } from '@common/hooks/use-paginate.ts';
import { useState } from 'react';
import { PaginableGrid } from '@components/grid/paginable-grid.tsx';
import { PaginateResult } from '@common/hooks/models/paginate-result.ts';
import MainCard from '@common/ui-component/cards/main-card.tsx';
import { ColumnDef } from '@components/grid/models/column-def.tsx';
import InfoIcon from '@mui/icons-material/Info';
import { Button } from '@components/button/button.tsx';
import { Dialog, DialogTitle, DialogContent, DialogActions } from '@mui/material';
import { useConfirmDialog } from '@components/dialog/confirm-dialog';

const RegistroCapacitacion = () => {
  const { success, error } = useNotification();
  const confirm = useConfirmDialog();
  const [claveEmpleado, setClaveEmpleado] = useState('');
  const [datosEmpleado, setDatosEmpleado] = useState(null);
  const [datosFaltantes, setDatosFaltantes] = useState(false);
  const [search, setSearch] = useState<any>({});
  const [openDialog, setOpenDialog] = useState(false);
  const [selectedCapacitacion, setSelectedCapacitacion] = useState<any>(null);

  const [{ data }] = usePaginate<any>(httpApi, '/capacitaciones/disponibles', search, {
    pageIn: 1,
    sizeIn: 5,
    sizeOptions: [5, 10],
  });

  const buscarEmpleado = async () => {
    try {
      const response = await httpApi.get(`/empleados/${claveEmpleado}`);
      setDatosEmpleado(response.data);
      setDatosFaltantes(!response.data.nombre || !response.data.cargo || !response.data.correo);
    } catch (err) {
      error('Error al buscar los datos del empleado.');
    }
  };

  const actualizarDatosEmpleado = async (nuevosDatos: any) => {
    try {
      await httpApi.put(`/empleados/${claveEmpleado}`, nuevosDatos);
      success('Datos actualizados correctamente.');
      setDatosEmpleado({ ...datosEmpleado, ...nuevosDatos });
      setDatosFaltantes(false);
    } catch (err) {
      error('Error al actualizar los datos del empleado.');
    }
  };

  const buscarCapacitaciones = () => {
    setSearch({
      nombre: search.nombre || '',
      modalidad: search.modalidad || '',
      fechaInicio: search.fechaInicio || '',
      fechaFin: search.fechaFin || '',
    });
  };

  const registrarse = async (id: string) => {
    confirm({
      description: '¿Estás seguro de que deseas registrarte en esta capacitación?',
    }).then(async (result) => {
      if (result) {
        try {
          const response = await httpApi.post(`/capacitaciones/${id}/registrarse`);
          if (response.data) {
            success('Registro exitoso en la capacitación.');
          }
        } catch (err) {
          error('Error al registrarte en la capacitación.');
        }
      }
    });
  };

  const columns: ColumnDef[] = [
    {
      headerName: 'Acciones',
      renderCell: (rowData: any) => (
        <>
          <Button
            color="secondary"
            startIcon={<InfoIcon />}
            onClick={() => {
              setSelectedCapacitacion(rowData);
              setOpenDialog(true);
            }}
          >
            Ver Detalles
          </Button>
          <Button
            color="primary"
            onClick={() => registrarse(rowData.id)}
          >
            Registrarse
          </Button>
        </>
      ),
    },
    {
      headerName: 'Nombre',
      field: 'nombre',
    },
    {
      headerName: 'Modalidad',
      field: 'modalidad',
    },
    {
      headerName: 'Fecha Inicio',
      field: 'fechaInicio',
      renderCell: (rowData: any) => new Date(rowData.fechaInicio).toLocaleDateString(),
    },
    {
      headerName: 'Fecha Fin',
      field: 'fechaFin',
      renderCell: (rowData: any) => new Date(rowData.fechaFin).toLocaleDateString(),
    },
  ];

  return (
    <>
      <MainCard xs={{ maxWidth: '1200px' }}>
        <div style={{ marginBottom: '20px' }}>
          <input
            type="text"
            placeholder="Clave de Empleado"
            value={claveEmpleado}
            onChange={(e) => setClaveEmpleado(e.target.value)}
            style={{ padding: '5px', width: '200px' }}
          />
          <Button onClick={buscarEmpleado}>Buscar</Button>
        </div>
        {datosEmpleado && (
          <div>
            <p><strong>Nombre:</strong> {datosEmpleado.nombre || 'N/A'}</p>
            <p><strong>Cargo:</strong> {datosEmpleado.cargo || 'N/A'}</p>
            <p><strong>Correo:</strong> {datosEmpleado.correo || 'N/A'}</p>
            {datosFaltantes && <Button onClick={() => actualizarDatosEmpleado(/* datos actualizados */)}>Actualizar Datos</Button>}
          </div>
        )}

        <div style={{ display: 'flex', gap: '10px', marginTop: '20px' }}>
          <input
            type="text"
            placeholder="Nombre"
            value={search.nombre || ''}
            onChange={(e) => setSearch({ ...search, nombre: e.target.value })}
            style={{ padding: '5px', width: '200px' }}
          />
          <select
            value={search.modalidad || ''}
            onChange={(e) => setSearch({ ...search, modalidad: e.target.value })}
            style={{ padding: '5px', width: '200px' }}
          >
            <option value="">Todas</option>
            <option value="presencial">Presencial</option>
            <option value="virtual">Virtual</option>
          </select>
          <input
            type="date"
            placeholder="Fecha Inicio"
            value={search.fechaInicio || ''}
            onChange={(e) => setSearch({ ...search, fechaInicio: e.target.value })}
            style={{ padding: '5px', width: '200px' }}
          />
          <input
            type="date"
            placeholder="Fecha Fin"
            value={search.fechaFin || ''}
            onChange={(e) => setSearch({ ...search, fechaFin: e.target.value })}
            style={{ padding: '5px', width: '200px' }}
          />
          <Button onClick={buscarCapacitaciones}>Buscar</Button>
        </div>

        <PaginableGrid
          paginable={data as PaginateResult<any>}
          columnDefs={columns}
        />
      </MainCard>

      <Dialog
        open={openDialog}
        onClose={() => setOpenDialog(false)}
        maxWidth="sm"
        fullWidth
      >
        <DialogTitle>Detalles de la Capacitación</DialogTitle>
        <DialogContent>
          {selectedCapacitacion && (
            <div>
              <p><strong>Nombre:</strong> {selectedCapacitacion.nombre}</p>
              <p><strong>Modalidad:</strong> {selectedCapacitacion.modalidad}</p>
              <p><strong>Descripción:</strong> {selectedCapacitacion.descripcion || 'N/A'}</p>
              <p><strong>Fecha de Inicio:</strong> {new Date(selectedCapacitacion.fechaInicio).toLocaleDateString()}</p>
              <p><strong>Fecha de Fin:</strong> {new Date(selectedCapacitacion.fechaFin).toLocaleDateString()}</p>
            </div>
          )}
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setOpenDialog(false)} color="primary">Cerrar</Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default RegistroCapacitacion;
