export interface ArtikliGetAllResponse {
  artikal: ArtikliGetAllResponseArtikli[]
}

export interface ArtikliGetAllResponseArtikli {
  id: number
  naziv: string
  cijena: number
  opis: string
  kratkiOpis: string
  stanjeNaSkladistu: number
  slikaArtikla: string
  sifra: number
  model: string
  popust: any
  proizvodjac: any
  artikalKategorija: any
  skladiste: any
}
