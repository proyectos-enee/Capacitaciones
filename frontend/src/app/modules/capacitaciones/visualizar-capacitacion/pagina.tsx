import { httpApi } from '../../../http/http-api.ts';
import { usePaginate } from '@common/hooks/use-paginate.ts';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { PaginableGrid } from '@components/grid/paginable-grid.tsx';
import { PaginateResult } from '@common/hooks/models/paginate-result.ts';
import MainCard from '@common/ui-component/cards/main-card.tsx';
import { ColumnDef } from '@components/grid/models/column-def.tsx';
import InfoIcon from '@mui/icons-material/Info';
import { Button } from '@components/button/button.tsx';
import { Dialog, DialogTitle, DialogContent, DialogActions } from '@mui/material';

const Pagina = () => {
  const [search, setSearch] = useState<any>({});
  const navigate = useNavigate();
  const [openDialog, setOpenDialog] = useState(false);
  const [selectedCapacitacion, setSelectedCapacitacion] = useState<any>(null); // Capacitación seleccionada

  // Configuración para paginar
  const [{ data }] = usePaginate<any>(httpApi, '/capacitacion/capacitaciones/disponibles', search, {
    pageIn: 1,
    sizeIn: 5,
    sizeOptions: [5, 10],
  });

  const buscarCapacitaciones = () => {
    setSearch({
      nombreCorto: search.nombreCorto || '',
      modalidad: search.modalidad || '',
      fechaInicioRegistro: search.fechaInicioRegistro || '',
      fechaFinRegistro: search.fechaFinRegistro || '',
    });
  };

  const columns: ColumnDef[] = [
    {
      headerName: 'Nombre Corto',
      field: 'nombreCorto',
    },
    {
      headerName: 'Modalidad',
      field: 'modalidad',
    },
    {
      headerName: 'Fecha Inicio',
      field: 'fechaInicioRegistro',
      renderCell: (rowData: any) =>
        rowData.fechaInicioRegistro
          ? new Date(rowData.fechaInicioRegistro).toLocaleDateString('es-ES')
          : 'Fecha no disponible',
    },
    {
      headerName: 'Fecha Fin',
      field: 'fechaFinRegistro',
      renderCell: (rowData: any) =>
        rowData.fechaFinRegistro
          ? new Date(rowData.fechaFinRegistro).toLocaleDateString('es-ES')
          : 'Fecha no disponible',
    },
    {
      // Columna de acciones
      renderCell: (rowData: any) => (
        <Button
          color="secondary"
          startIcon={<InfoIcon />}
          onClick={() => {
            console.log('Datos seleccionados:', rowData); // Debugging
            setSelectedCapacitacion(rowData);
            setOpenDialog(true);
          }}
          key={rowData.id}
        >
          Ver Detalles
        </Button>
      ),
    },
  ];

  return (
    <>
      <MainCard xs={{ maxWidth: '1200px' }}>
        <div
          style={{
            display: 'flex',
            justifyContent: 'space-between',
            marginTop: '20px',
          }}
        >
          {/* Filtros */}
          <div style={{ display: 'flex', gap: '10px' }}>
            <input
              type="text"
              placeholder="Nombre Corto"
              value={search.nombreCorto || ''}
              onChange={(e) => setSearch({ ...search, nombreCorto: e.target.value })}
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
              <option value="hibrido">Híbrido</option>
            </select>
            <input
              type="date"
              placeholder="Fecha Inicio"
              value={search.fechaInicioRegistro || ''}
              onChange={(e) =>
                setSearch({ ...search, fechaInicioRegistro: e.target.value })
              }
              style={{ padding: '5px', width: '200px' }}
            />
            <input
              type="date"
              placeholder="Fecha Fin"
              value={search.fechaFinRegistro || ''}
              onChange={(e) =>
                setSearch({ ...search, fechaFinRegistro: e.target.value })
              }
              style={{ padding: '5px', width: '200px' }}
            />
            <Button onClick={buscarCapacitaciones}>Buscar</Button>
          </div>
        </div>

        {/* Tabla de capacitaciones */}
        <PaginableGrid
          paginable={data as PaginateResult<any>}
          columnDefs={columns}
          getRowId={(row: any) => row.id} // Asignar una key única para cada fila
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
                <strong>Nombre Corto:</strong> {selectedCapacitacion.nombreCorto || 'N/A'}
              </p>
              <p>
                <strong>Modalidad:</strong> {selectedCapacitacion.modalidad || 'N/A'}
              </p>
              <p>
                <strong>Descripción:</strong> {selectedCapacitacion.descripcion || 'N/A'}
              </p>
              <p>
                <strong>Fecha de Inicio:</strong>
                {selectedCapacitacion.fechaInicioRegistro
                  ? new Date(selectedCapacitacion.fechaInicioRegistro).toLocaleDateString('es-ES')
                  : 'Fecha no disponible'}
              </p>
              <p>
                <strong>Fecha de Fin:</strong>
                {selectedCapacitacion.fechaFinRegistro
                  ? new Date(selectedCapacitacion.fechaFinRegistro).toLocaleDateString('es-ES')
                  : 'Fecha no disponible'}
              </p>
              <p>
                <strong>Lugar:</strong> {selectedCapacitacion.lugar || 'N/A'}
              </p>
            </div>
          )}
        </DialogContent>
        <DialogActions>
          <Button onClick={() => navigate('/capacitaciones/registro')} color="primary">
            Registrarse
          </Button>
          <Button onClick={() => setOpenDialog(false)} color="primary">
            Cerrar
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default Pagina;
