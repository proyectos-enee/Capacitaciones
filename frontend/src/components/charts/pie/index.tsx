import {
  ChartsLegend,
  ChartsTooltip,
  PiePlot,
  ResponsiveChartContainer,
} from '@mui/x-charts';
import { PieProps, Styles, PieSize } from './types';
import { Paper, Typography } from '@mui/material';
import { useTheme } from '@mui/material/styles';
import useMediaQuery from '@mui/material/useMediaQuery';
import { CustomTheme } from '@common/themes/default/types/customTheme';
import { defaultPalette } from '../color-palette';

const defaultStyles: Styles = {
  innerRadius: 100,
  paddingAngle: 4,
  cornerRadius: 7,
  highlightScope: { faded: 'global', highlighted: 'item' },
  faded: { innerRadius: 30, additionalRadius: -30, color: 'gray' },
};

const defaultSize: PieSize = { height: 520 };

const Pie = ({
  data,
  styles = defaultStyles,
  size = defaultSize,
  title,
  titleColor,
  palette = defaultPalette,
}: PieProps) => {
  const hideLegend: boolean = data.length > 6;
  const theme = useTheme<CustomTheme>();
  const isSmallScreen = useMediaQuery(theme.breakpoints.down('sm'));
  return (
    <Paper
      sx={{
        width: '100%',
        height: size,
        display: 'flex',
        flexDirection: 'column',
        borderRadius: theme.custom.borderRadius.r1,
      }}
      elevation={0}
    >
      {title && (
        <Typography
          variant="h3"
          noWrap
          sx={{
            padding: '40px 0 5px 40px',
            color: titleColor ? titleColor : undefined,
          }}
        >
          {title}
        </Typography>
      )}

      <ResponsiveChartContainer
        sx={{ paddingLeft: isSmallScreen ? 0 : 6 }}
        series={[
          {
            type: 'pie',
            data: data,
            ...styles,
          },
        ]}
        colors={palette}
      >
        <PiePlot />
        <ChartsLegend
          hidden={hideLegend}
          slotProps={{
            legend: {
              direction: isSmallScreen ? 'row' : 'column',
              position: { vertical: 'top', horizontal: 'left' },
              padding: 0,
            },
          }}
        />
        <ChartsTooltip trigger="item" />
      </ResponsiveChartContainer>
    </Paper>
  );
};

export default Pie;
