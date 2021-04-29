import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface AuthorCreateDto {
  nameSurname?: string;
  age?: number;
}

export interface AuthorDto extends FullAuditedEntityDto<string> {
  nameSurname?: string;
  age?: number;
}

export interface AuthorUpdateDto {
  nameSurname?: string;
  age?: number;
}

export interface GetAuthorsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  nameSurname?: string;
  ageMin?: number;
  ageMax?: number;
}
