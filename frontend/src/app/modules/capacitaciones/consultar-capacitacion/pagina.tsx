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
  const [search, setSearch] = useState<any>({});
  const [openDialog, setOpenDialog] = useState(false); // Control del diálogo
  const [selectedCapacitacion, setSelectedCapacitacion] = useState<any>(null); // Capacitación seleccionada

  // Configuración para paginar
  const [{ data }] = usePaginate<any>(httpApi, '', search, {
    pageIn: 1,
    sizeIn: 5,
    sizeOptions: [5, 10],
  });

  const buscarCapacitaciones = () => {
    setSearch({
      codigoCapacitacion: search.codigoCapacitacion || '',
      nombreCorto: search.nombreCorto || '',
    });
  };

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
      icon: <EditIcon />,
      label: 'Editar',
      onClick: (rowData: any) => {
        navigate(`/capacitaciones/actualizar/${rowData.id}`);
      },
    },
    {
      color: 'secondary',
      icon: <InfoIcon />,
      label: 'Ver Detalles',
      onClick: (rowData: any) => {
        setSelectedCapacitacion(rowData); // Almacena los datos de la capacitación
        setOpenDialog(true); // Abre el diálogo
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
  ];

  const nuevaCapacitacion = () => {
    navigate('/capacitaciones/crear');
  };

  return (
    <>
      <MainCard xs={{ maxWidth: '1200px' }}>
        <GroupToolbar>
          <BtnGroup>
            <Button onClick={buscarCapacitaciones}>Buscar</Button>
            <Button onClick={nuevaCapacitacion}>Crear Capacitación</Button>
          </BtnGroup>
        </GroupToolbar>

        {/* Formulario de Búsqueda */}
        <div style={{ display: 'flex', justifyContent: 'space-between', marginTop: '20px' }}>
          <div style={{ display: 'flex', gap: '10px' }}>
            <input
              type="text"
              placeholder="Código de Capacitación"
              value={search.codigoCapacitacion || ''}
              onChange={(e) => setSearch({ ...search, codigoCapacitacion: e.target.value })}
              style={{ padding: '5px', width: '200px' }}
            />
            <input
              type="text"
              placeholder="Nombre Corto"
              value={search.nombreCorto || ''}
              onChange={(e) => setSearch({ ...search, nombreCorto: e.target.value })}
              style={{ padding: '5px', width: '200px' }}
            />
            <Button onClick={buscarCapacitaciones}>Buscar</Button>
          </div>
        </div>

        <PaginableGrid paginable={data as PaginateResult<any>} columnDefs={columns} />
      </MainCard>

      {/* Diálogo de Detalles */}
      <Dialog open={openDialog} onClose={() => setOpenDialog(false)} maxWidth="sm" fullWidth>
        <DialogTitle>Detalles de la Capacitación</DialogTitle>
        <DialogContent>
          {selectedCapacitacion && (
            <div>
              <p><strong>Id:</strong> {selectedCapacitacion.id}</p>
              <p><strong>Código:</strong> {selectedCapacitacion.codigoCapacitacion}</p>
              <p><strong>Nombre Corto:</strong> {selectedCapacitacion.nombreCorto}</p>
              <p><strong>Nombre Largo:</strong> {selectedCapacitacion.nombreLargo || 'N/A'}</p>
              <p><strong>Descripción:</strong> {selectedCapacitacion.descripcion || 'N/A'}</p>
              <p><strong>Estado:</strong> {selectedCapacitacion.estado}</p>
              <p><strong>Modalidad:</strong>{' '} {selectedCapacitacion.modalidad?.name || 'N/A'}</p>
              <p>
                <strong>Fecha de Inicio:</strong>{' '}
                {selectedCapacitacion.fechaInicioRegistro
                  ? new Date(selectedCapacitacion.fechaInicioRegistro).toLocaleDateString()
                  : 'N/A'}
              </p>
              <p>
                <strong>Fecha de Fin:</strong>{' '}
                {selectedCapacitacion.fechaFinRegistro
                  ? new Date(selectedCapacitacion.fechaFinRegistro).toLocaleDateString()
                  : 'N/A'}
              </p>
              <p><strong>Lugar:</strong> {selectedCapacitacion.lugar || 'N/A'}</p>
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
