import { useConfirmDialog } from '@components/dialog/confirm-dialog';
import { useNotification } from '@components/snackbar/use-notification.ts';
import { httpApi } from '../../../http/http-api.ts';
import { usePaginate } from '@common/hooks/use-paginate.ts';
import { useState } from 'react';
import { PaginableGrid } from '@components/grid/paginable-grid.tsx';
import { PaginateResult } from '@common/hooks/models/paginate-result.ts';
import MainCard from '@common/ui-component/cards/main-card.tsx';
import { ColumnDef } from '@components/grid/models/column-def.tsx';
import { ActionColumn, generateActionColumn } from '@components/grid/components/action-column.tsx';
import DeleteIcon from '@mui/icons-material/Delete';
import { modalidades } from '../common/capacitacion-formulario';
import EditIcon from '@mui/icons-material/Edit';
import InfoIcon from '@mui/icons-material/Info';
import { Button } from '@components/button/button.tsx';
import { BtnGroup, GroupToolbar } from '@components/toolbar-group/group-toolbar.tsx';
import { Dialog, DialogTitle, DialogContent, DialogActions } from '@mui/material';
import { useNavigate } from 'react-router';

const Pagina = () => {
  const navigate = useNavigate();
  const confirm = useConfirmDialog();
  const { success, error } = useNotification();
  const [openDialog, setOpenDialog] = useState(false); // Control del diálogo de "Ver Detalles"
  const [selectedCapacitacion, setSelectedCapacitacion] = useState<any>(null); // Capacitación seleccionada
  const [search] = useState<any>({});

  // Configuración para paginar
  const [{ data }] = usePaginate<any>(httpApi, 'capacitacion', search, {
    pageIn: 1,
    sizeIn: 5,
    sizeOptions: [5, 10],
  });

  const actions: Array<ActionColumn> = [
    {
      color: 'error',
      icon: <DeleteIcon />,
      onClick: (rowData: any) => {
        confirm({
          description: '¿Seguro que deseas eliminar esta capacitación?',
        }).then((result) => {
          if (result) {
            fetch(`http://localhost:5090/api/v1/capacitacion/${rowData.id}`, { method: 'DELETE' })
              .then((response) => {
                if (response.ok) {
                  success('Capacitación ha sido eliminada');

                } else {
                  error('Error al eliminar');
                }
              })
              .catch((err) => {
                console.error('Error en la petición:', err);
                error('Error en la eliminación de la capacitación');
              });
          }
        });
      },
    },
    {
      color: 'primary',
      icon: <EditIcon />, // Ícono para editar
      label: 'Editar',
      onClick: (rowData: any) => {
        navigate(`/capacitaciones/actualizar/${rowData.id}`, {
          state: { capacitacion: rowData }, // Pasa los datos de la capacitación seleccionada como estado
        });
      },
    },
    {
      color: 'secondary',
      icon: <InfoIcon />,
      label: 'Ver Detalles',
      onClick: (rowData: any) => {
        // Abre el cuadro de diálogo para mostrar los detalles
        setSelectedCapacitacion(rowData);
        setOpenDialog(true);
      },
    },
  ];

  const columns: ColumnDef[] = [
    {
      headerName: 'Acciones',
      renderCell: generateActionColumn(actions),
    },
    {
      headerName: 'Código Capacitación',
      field: 'codigoCapacitacion',
    },

    {
      headerName: 'Nombre Corto',
      field: 'nombreCorto',
    },
    {
      headerName: 'Estado',
      field: 'estado',
    },
    {
      headerName: 'Modalidad',
      field: 'modalidad',
    },
    {
      headerName: 'Fecha Inicio',
      field: 'fechaInicioRegistro',
    },
    {
      headerName: 'Lugar',
      field: 'lugar',
    },
    {
      headerName: 'Horario',
      field: 'horario',
    },
  ];

  const nuevaCapacitacion = () => {
    navigate('/capacitaciones/crear');
  };

  return (
    <>
      <MainCard xs={{ maxWidth: '1200px' }}>
        <GroupToolbar>
          <BtnGroup>
            <Button onClick={nuevaCapacitacion}>Crear Capacitación</Button>
          </BtnGroup>
        </GroupToolbar>

        <PaginableGrid
          paginable={data as PaginateResult<any>}
          columnDefs={columns}
        />
      </MainCard>

      {/* Diálogo de Detalles */}
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
              <p>
                <strong>Id:</strong> {selectedCapacitacion.id}
              </p>
              <p>
                <strong>Código:</strong>{' '}
                {selectedCapacitacion.codigoCapacitacion}
              </p>
              <p>
                <strong>Horario:</strong>{' '}
                {selectedCapacitacion.horario || 'N/A'}
              </p>
              <p>
                <strong>Nombre Corto:</strong>{' '}
                {selectedCapacitacion.nombreCorto}
              </p>
              <p>
                <strong>Nombre Largo:</strong>{' '}
                {selectedCapacitacion.nombreLargo || 'N/A'}
              </p>
              <p>
                <strong>Descripción:</strong>{' '}
                {selectedCapacitacion.descripcion || 'N/A'}
              </p>
              <p>
                <strong>Estado:</strong> {selectedCapacitacion.estado}
              </p>
              <p>
                <strong>Modalidad:</strong>
                {modalidades.find(m => m.id === selectedCapacitacion.modalidad)
                  ?.name || 'N/A'}
              </p>

              <p>
                <strong>Fecha de Inicio:</strong>{' '}
                {selectedCapacitacion.fechaInicioRegistro
                  ? new Date(
                    selectedCapacitacion.fechaInicioRegistro,
                  ).toLocaleDateString()
                  : 'N/A'}
              </p>
              <p>
                <strong>Fecha de Fin:</strong>{' '}
                {selectedCapacitacion.fechaFinRegistro
                  ? new Date(
                    selectedCapacitacion.fechaFinRegistro,
                  ).toLocaleDateString()
                  : 'N/A'}
              </p>
              <p>
                <strong>Lugar:</strong> {selectedCapacitacion.lugar || 'N/A'}
              </p>
            </div>
          )}
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setOpenDialog(false)} color="primary">
            Cerrar
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default Pagina;
