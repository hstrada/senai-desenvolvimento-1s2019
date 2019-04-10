function jwt(token) {
    //Pega a segunda posição do array
    var base64Url = token.split('.')[1];
    //altera onde esta - para + e onde esta _ para /
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    // A função WindowBase64.atob() decodifica uma string de dados que foi codificada através da codificação base-64. Você pode usar o método window.btoa() para codificar e transmitir dados que, se não codificados, podem causar problemas de comunicação. Após transmití-los pode-se usar o método window.atob() para decodificar os dados novamente. Por exemplo, você pode codificar, transmitir,  e decodificar caracteres de controle como valores ASCII de 0 a 31.
    //JSON.parse - Converte texto em object
    return JSON.parse(window.atob(base64));
};

export default jwt;