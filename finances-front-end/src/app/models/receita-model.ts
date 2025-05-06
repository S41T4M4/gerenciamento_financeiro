export interface Receita{
    id_receita: number,
    descricao: string;
    valor: number;
    recorrente: boolean;
    id_conta: number;
}