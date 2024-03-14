

export type Product = {
    id: number;
    name: string;
    price: number;
    barCode: string;
    imageUrl: string;
}

export type PaginatedProduct = {
    products: Product[],
    total: number;
    pageIndex: number;
}