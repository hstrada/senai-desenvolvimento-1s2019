import React from 'react';
import Link from '@material-ui/core/Link';
import Typography from '@material-ui/core/Typography';

function DesenvolvidoPor() {
    return (
      <Typography variant="body2" color="textSecondary" align="center">
        {'Desenvolvido por  '}
        <Link color="inherit" href="https://informatica.sp.senai.br/">
          Senai Informática
        </Link>
      </Typography>
    );
  }

  export default DesenvolvidoPor;