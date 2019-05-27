import React from "react";
import DesenvolvidoPor from "./DesenvolvidoPor";
import { makeStyles } from "../../node_modules/@material-ui/core/styles";

import Typography from "@material-ui/core/Typography";

const useStyles = makeStyles(theme => ({
  footer: {
    backgroundColor: theme.palette.background.paper,
    padding: theme.spacing(6)
  }
}));

function Rodape() {
  const classes = useStyles();

  return (
    <footer className={classes.footer}>
      <Typography variant="h6" align="center" gutterBottom>
        SviGufo
      </Typography>
      <Typography
        variant="subtitle1"
        align="center"
        color="textSecondary"
        component="p"
      >
        Aprender nunca é demais e mal não faz
      </Typography>
      <DesenvolvidoPor />
    </footer>
  );
}

export default Rodape;
