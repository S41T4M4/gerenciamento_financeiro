export interface Despesa{
    id_despesa: number,
    descricao: string;
    valor: number;
    data_despesa: Date;
    id_categoria: number;
    recorrente: boolean;
    id_conta: number;
    categoria: {
        id_categoria: number;
        nome_categoria: string;
    }
}